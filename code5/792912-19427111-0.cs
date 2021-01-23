    static void Main()
        {
            try
            {              
                // Open file for reading.
                using (StreamReader r = new StreamReader(@"C:\LogFile.log"))
                {
                    // 2.
                    // Read each line until EOF.
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        // 3.
                        // Do stuff with line.
                        if (line.Contains("Files"))
                        {
                            if (!line.Contains("Files : *.*"))
                            {
                                String content = line.ToString();
                                string[] splitContent = System.Text.RegularExpressions.Regex.Replace(content, @"\s+", " ").Split(' ');
                                //foreach (string s in splitContent)
                                //Console.WriteLine(s);
                                Console.WriteLine(splitContent[3]);
                            }                           
                        }                        
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
