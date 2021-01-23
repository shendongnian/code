    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    namespace book_StreamWriter
    {
        class FileWrite
        {
            public void writeData()
            {
               using(FileStream fs =
                    new FileStream(@"D:\myfile2.txt",
                                    FileMode.Append, FileAccess.Write))
               {
                  StreamWriter sw = new StreamWriter(fs);
                  Console.WriteLine("Enter a string :");
                  string str = Console.ReadLine();
                  sw.Write(str);
                  sw.Flush();
                  sw.Close();
                  fs.Close();
               }
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                FileWrite fw = new FileWrite();
                fw.writeData();
                Console.ReadLine();
            }
        }
    }
