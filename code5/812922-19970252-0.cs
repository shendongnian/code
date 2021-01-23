    StreamReader fileI = new StreamReader("C:\\Users\\Harsha\\Desktop\\SampleInput.txt");
            StreamWriter fileA = new StreamWriter("C:\\Users\\Harsha\\Desktop\\A.txt", true);
            StreamWriter fileB = new StreamWriter("C:\\Users\\Harsha\\Desktop\\B.txt", true);
            StreamWriter fileC = new StreamWriter("C:\\Users\\Harsha\\Desktop\\C.txt", true);
           
            string line;
            int counter = System.IO.File.ReadAllLines("C:\\Users\\Harsha\\Desktop\\SampleInput.txt").Length;
            for (int linenum = 0; linenum <= counter; linenum++)
            {
                if ((line = fileI.ReadLine()) != null)
                {
                    string c1 = (line.ElementAt<char>(6)).ToString();
                    string c2 = (line.ElementAt<char>(7)).ToString();
                    string c3 = (line.ElementAt<char>(8)).ToString();
                    string c4 = c1 + c2 + c3;
                    if (c4 == "CSE")
                    {
                        
                            fileA.WriteLine(line);
                    }
                    else if(c4=="EEE")
                    {
                            fileB.WriteLine(line);
                    }
                    else if(c4=="EIE")
                    {
                        fileC.WriteLine(line);
                    }
                }
            }
            
            fileI.Close();
            fileA.Close();
            fileB.Close();
            fileC.Close();
