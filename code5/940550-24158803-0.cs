                    string line;
                    StreamWriter sw = new StreamWriter(insertFile);
                    using (StreamReader sr = new StreamReader(sourcePath))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            sw.WriteLine(line.Replace("\"", ""));
                        }
                        sr.Close();
                        sw.Close();
                        sr.Dispose();
                        sw.Dispose();
                        File.Copy(insertFile, @"\\SQLSERVER\C$\insert.csv");
                    }
