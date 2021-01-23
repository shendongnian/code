    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    
    namespace ConsoleApplicationExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                Runner r = new Runner();
                r.SplitFile(@"C:\path\to\my\file.txt");
            }
        }
    
        public class Runner
        {
            private readonly string m_delimiter;
    
            public Runner()
            {
                m_delimiter = "Finished File";
            }
    
            public void SplitFile(string inputFile)
            {
                try
                {
                    StreamReader reader = new StreamReader(inputFile);
                    StreamWriter writer;
    
                    int i = 1;                              // count up for every output   file, auto-numbering from 1
                    string line;                    
                    do
                    {
                        string outputFile = GenerateFileName(inputFile, i);
                        writer = new StreamWriter(outputFile);
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.CompareTo(m_delimiter) == 0)
                            {
                                writer.Close();
                                break;                      // breaking will exit the  while-loop & increment i to build a new output file name
                            }
                            else
                                writer.WriteLine(line);
                        }
                        i++;
                    } while (line != null);
                    writer.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error splitting file: " + ex.ToString());
                }
            }
     
            private string GenerateFileName(string inputFile, int i)
            {
                string folder = Path.GetFullPath(inputFile);
                string fileNameNoExt = Path.GetFileNameWithoutExtension(inputFile);
                string ext = Path.GetExtension(inputFile);
                return folder + fileNameNoExt + "." + i.ToString("000") + ext;          //  zero-pads "000"
            }
        }
    }
