     var sr = new StreamReader("file.csv");
                var writeToFile = new StreamWriter("out.csv");
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    writeToFile.WriteLine(sr.ReadLine().ToString().Replace(",7.00", ""));
                }
                writeToFile.Close();
                sr.Close();
