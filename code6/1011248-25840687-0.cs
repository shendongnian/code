    using System;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string file = @"D:\information.txt";
                if (File.Exists(file))
                    foreach(var s in File.ReadAllLines(file))
                        Console.WriteLine(s);
                else
                {
                    string[] src = new string[5];
                    Console.WriteLine("Please enter 5 names:");
                    for (int i = 0; i < 5; i++)
                        src[i] = Console.ReadLine();
                    File.Create(file).Close();
                    File.WriteAllLines(file, src)
                }
            }
        }
    }
