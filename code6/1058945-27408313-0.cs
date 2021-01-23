     Dictionary<string, string> userPass_dict = new Dictionary<string, string>(); // add this at class level
     using (StreamReader sr = new StreamReader("TextFile1.txt"))
            {
                string line = "";
                string line2 = "";
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    line2 = sr.ReadLine();
                    userPass_dict.Add(line, line2);
                }
                
            }
