using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.Title = "Практическая работа 11";

            Console.WriteLine("Здравствуй!");

            bool continueProgram = true;

            while (continueProgram)
            {
                try
                {
                    Console.WriteLine("\nПроверка, является ли строка палиндромом.");

                    Console.Write("Введите строку: ");
                    string str = Console.ReadLine();

                    if (String.IsNullOrEmpty(str))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Строка пуста, вы ничего не ввели! Попробуйте снова.");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }

                    string str1 = str.Replace(" ", "");

                    if (str1.Length == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Строка состоит только из пробелов! Введите что-то осмысленное.");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }

                    bool hasLetter = false;
                    foreach (char c in str1)
                    {
                        if (Char.IsLetter(c))
                        {
                            hasLetter = true;
                            break;
                        }
                    }
                    if (!hasLetter)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("В строке нет ни одной буквы! Введите слово или фразу.");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }

                    char[] charArray = str1.ToCharArray();

                    Array.Reverse(charArray);

                    string str2 = new string(charArray);

                    int result = String.Compare(str1, str2, true);

                    if (result == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Это палиндром.");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Это не палиндром.");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (OutOfMemoryException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка памяти: строка слишком длинная. " + ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (FormatException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка формата: " + ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Произошла непредвиденная ошибка: " + ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }

                bool answerA = false;
                while (!answerA)
                {
                    Console.Write("\nПродолжить выполнение программы? (да/нет): ");
                    string answer = Console.ReadLine();

                    if (answer == null) answer = "";

                    if (answer.ToLower() == "да")
                    {
                        answerA = true;
                    }
                    else if (answer.ToLower() == "нет")
                    {
                        answerA = true;
                        continueProgram = false;
                        Console.WriteLine("Выход из программы. До свидания!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ошибка: введите \"да\" или \"нет\".");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
