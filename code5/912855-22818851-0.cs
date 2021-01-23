    using System;
    using System.IO;
    
    class Program
    {
        const string FileName = "MyFile.txt";
        static void Main(string[] args)
        {
            Console.WriteLine("Please Select One Of The Following Options... ");
            Console.WriteLine("1. Enter A New Record In The File.");
            Console.WriteLine("2. Read All The Records From The File.");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddEntry();
                    break;
                case 2:
                    ReadFile();
                    break;
                default:
                    Console.WriteLine("Sorry, that's not a valid option");
                    break;
            }
       }
            
       static void AddEntry()
       {
           Console.WriteLine("Enter the ID:");
           int id = int.Parse(Console.ReadLine());
           Console.WriteLine("Enter the name:");
           string name = Console.ReadLine();
           File.AppendAllLines(FileName, new[] { id.ToString(), name });
       }
       static void ReadFile()
       {
           foreach (var line in File.ReadLines(FileName))
           {
               Console.WriteLine(line);
           }
       }
    }
