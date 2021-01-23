    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Configuration;
    using System.Diagnostics;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string sFileName = Properties.Settings.Default.ab123;
                // Check if ab123 has a value and the file exists
                if (!string.IsNullOrEmpty(sFileName) && System.IO.File.Exists(sFileName))
                {
                    using (StreamReader sr = new StreamReader(sFileName))
                    {
                        string line;
                        // Read and display lines from the file until the end of  
                        // the file is reached. 
                        while ((line = sr.ReadLine()) != null)
                        {
                            System.Diagnostics.Debug.WriteLine(line);
                        }
                    }
                }
            }
        }
    }
