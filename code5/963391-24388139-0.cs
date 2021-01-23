    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace FileInputOutput
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Use the Split() method of the String Class
                string fullname = " Robert Gordon Orr ";
                fullname = fullname.Trim();
                string[] splitNameArray = fullname.Split(' ');
                Console.WriteLine("First Name is: {0}", splitNameArray[0]);
                Console.WriteLine("Middle Name is: {0}", splitNameArray[1]);
                Console.WriteLine("Last Name is: {0}", splitNameArray[2]);
                Console.WriteLine("Full name is: {0}", fullname);
                string path = @"C:\textfile.txt";
    
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    using (StreamWriter toFile = new StreamWriter(fs))
                    {
                        toFile.Write(fullname);
                    }
                }
                //System.IO.File.WriteAllText(path, fullname);`enter code here`
    
                Console.ReadLine();
    
            }
        }
    }
