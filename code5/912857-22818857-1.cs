    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace F01
    {
        class Program
        {
            static int ID;
            static String Name;
            static void Main(string[] args)
            {
                using(FileStream MyFiler = new FileStream("MyFile.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using(StreamReader FileReader = new StreamReader(MyFiler))
                    {
                        using(StreamWriter FileWriter = new StreamWriter(MyFiler))
                        {
                            Console.WriteLine("Please Select One Of The Following Options... ");
                            Console.WriteLine("1. Enter A New Record In The File.");
                            Console.WriteLine("2. Read All The Records From The File.");
                            int Choice = int.Parse(Console.ReadLine());
                            if (Choice == 1)
                            {
                                Console.WriteLine("Enter The ID: ");
                                ID = int.Parse(Console.ReadLine());
                                FileWriter.WriteLine(ID);
                                Console.WriteLine("Enter The Name: ");
                                Name = Console.ReadLine();
                                FileWriter.WriteLine(Name);
                            }
        
                            else if (Choice == 2)
                            {
                                FileWriter.Close();
                                String fileText = File.ReadAllText("MyFile.txt");
                                for (int i = 0; i < fileText.Length; i++)
                                {
                                    Console.Write(fileText[i]);
                                }
                            }
                            FileReader.Close();
                        }
                    }
                }
            }
        }
    }
