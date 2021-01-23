    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    namespace StringLineSpaceAdd
    {
        class Program
        {
            static void Main(string[] args)
            {
                TextReader r = File.OpenText(@"D:\myFile.txt");
                string currentLine="";
                HashSet<string> previousLines = new HashSet<string>();
                TextWriter w = File.CreateText(@"D:\\newFile.txt");
                while ((currentLine = r.ReadLine()) != null)
                {
                    // Add returns true if it was actually added,
                    // false if it was already there
                    if (previousLines.Add(currentLine))
                    {
                        currentLine = " " + currentLine + " ";
                        w.WriteLine(currentLine);
                    }
                }
                w.Close();
            }
        }
    }
