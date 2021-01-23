    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    using System.IO;
    
    namespace UniqueListofStringFinder
    {
        class Program
        {
            static void Main(string[] args)
            {
                string path = @"c:\Your Path\in.txt";
                string pathOut = @"c:\Your Path\out.txt";
                string data = "!";
    
                Console.WriteLine("Current Path In is set to: " + path);
                Console.WriteLine("Current Path Out is set to: " + pathOut);
                Console.WriteLine(Environment.NewLine + Environment.NewLine + "Input String to Search For:");
                Console.Read();
                string input = Console.ReadLine();            
    
                // Delete the file if it exists. 
                if (!File.Exists(path))
                {
                    // Create the file. 
                    using (FileStream fs = File.Create(path))
                    {
                        Byte[] info =
                            new UTF8Encoding(true).GetBytes("This is some text in the file.");
    
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                    }
                }
    
                System.IO.StreamReader file = new System.IO.StreamReader(path);
                List<string> Spec = new List<string>();
    
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!file.EndOfStream)
                    {
                        string s = file.ReadLine();
                        if (s.Contains(input))
                        {                            
                            char[] delimiters = new char[] { '\r', '\n', '\t', ')', '(', ',', '=', '"', '\'', '<', '>', '$', ' ', '@', '[', ']' };
                            string[] parts = s.Split(delimiters,
                                             StringSplitOptions.RemoveEmptyEntries);
    
                            foreach (string word in parts)
                            {
                                if (word.Contains(input))
                                {                                   
                                    if( word.IndexOf(input) == 0)
                                    {
                                        Spec.Add(word);
                                    }
                                }
                            }                            
                        }
                    }
    
    
                    Spec.Sort();
    
                    // Open the stream and read it back. 
                    
                    //while ((s = sr.ReadLine()) != null)
                    //{
                    //    Console.WriteLine(s);
                    //}
                }
                Console.WriteLine();
    
                StringBuilder builder = new StringBuilder();
                foreach (string s in Spec) // Loop through all strings
                {
                    builder.Append(s).Append(Environment.NewLine); // Append string to StringBuilder
                }
                string result = builder.ToString(); // Get string from StringBuilder
    
    
                Program a = new Program();
    
                data = a.uniqueness(result);
    
                int i = a.writeFile(data,pathOut);
    
            }
    
            public string uniqueness(string rawData )
            {
                if (rawData == "")
                {
                    return "Empty Data Set";
                }
                
                List<string> dataVar = new List<string>();  
                List<string> holdData = new List<string>();
    
                bool testBool = false;
                using (StringReader reader = new StringReader(rawData))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {    
    
                        foreach (string s in holdData)
                        {
                            if (line == s)
                            {
                                testBool = true;
                            }
                        }
                        if (testBool == false)
                        {
                            holdData.Add(line);
                        }
                        testBool = false;
                        // Do something with the line
                    }
                }    
                
                int i = 0;
                string dataOut = "";
                foreach (string s in holdData)
                {                   
                    dataOut += s + "\r\n";
                    i++;
                }
    
                // Write the string to a file.
                return dataOut;
            }
    
            public int writeFile(string dataOut, string pathOut)
            {
                try
                {
                    System.IO.StreamWriter file = new System.IO.StreamWriter(pathOut);
                    file.WriteLine(dataOut);
    
                    file.Close();
                }
                catch (Exception ex)
                {
                    dataOut += ex.ToString();
                    return 1;
                }
                return 0;
            }
        }
    }
