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
                string path = @"C:\";
                FileAttributes attributes = File.GetAttributes(path);
    
                switch (attributes)
                {
                    case FileAttributes.Directory:
                        if (Directory.Exists(path))
                            Console.WriteLine("This directory exists.");
                        else
                            Console.WriteLine("This directory does not exist.");
                        break;
                    default:
                        if (Directory.Exists(path))
                            Console.WriteLine("This file exists.");
                        else
                            Console.WriteLine("This file does not exist.");
                        break;
                }
            }
        }
    }
