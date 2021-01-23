    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    
    
    
    namespace chomp
    {
        class Program
        {
            static string GenerateFileName(string context)
            {
                return context + "_" + Guid.NewGuid().ToString() + ".edi"; // DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".edi";
            }
            static int Main(string[] args)
            {
                string delimiter = "\r\n\r\n";
                if (args.Length == 0)
                {
    
                    Console.WriteLine("Please enter a file name: ");
                    return 1;
                }
                else
                {
    
                    try
                    {
    
                        string fileName = (args[0]);
                        if (File.Exists(fileName))
                        {
                            System.IO.StreamReader myFile =
                            new System.IO.StreamReader(fileName);
                            string FileStream = myFile.ReadToEnd();
                            myFile.Close();
    
                            string[] FSPart = FileStream.Split(new string[] { delimiter }, StringSplitOptions.None);
                            foreach (string s in FSPart)
                            {
                                string myFileName = GenerateFileName("DOC");
                                System.IO.StreamWriter file = new System.IO.StreamWriter(myFileName, false);
                                file.WriteLine(s);
                                file.Close();
                            }
                            return 0;
                        }
                        else
                        {
                            System.Console.WriteLine("Filename " + fileName + " does not exist!");
                            return 0;
                        } // closes else + if File.Exists
                    }
                    catch (System.FormatException)
                    {
                        Console.WriteLine("A Filename must be entered!");
                        return 1;
                    }
                }
            } //closes main
    
        } //closes program
    } //closes main
