    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
    
            }
            private static void LogEmailSent(DateTime date)
            {
                using(StreamWriter writer = new StreamWriter("my path"))
                {
                    writer.WriteLine(date);
    
                }
            }
            private static bool EmailSent()
            {
                bool logged = false;
    
                //It is a good idea to include try catch and a good idea to check if the file exists;
                if (!File.Exists("my file"))
                    return false;
    
                using(StreamReader rdr = new StreamReader("my path"))
                {
    
                    while(!rdr.EndOfStream)
                    {
                        string line = rdr.ReadLine();
                        DateTime dateLogged = Convert.ToDateTime(line);
                        TimeSpan difference = DateTime.Now.Subtract(dateLogged);
                        if(difference.TotalMinutes <= 30)
                        {
                            logged = true;
                        }
                        
    
                        break; //the file contains a line, so try to parse the datetime;
    
                    }
                }
                return logged;
    
            }
        }
    }
