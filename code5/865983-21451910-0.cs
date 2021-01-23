                try
                {
                    int counter = 0;
                    //Pass the file path and name to the StreamReader constructer
                    StreamReader sr = new StreamReader("gamenam.txt");
                    //Pass the file path and name to the StreamReader constructer
                    StreamWriter sw = new StreamWriter("gamenam_1.txt");
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        if (line.Substring(0, 2) == "03")
                        {
                            counter++;
                        }
                        sw.WriteLine(line);
                        line = sr.ReadLine();
                        if ((line == null) || (line.StartsWith("05")))
                        {
                            sw.WriteLine(counter.ToString());
                            counter = 0;
                        }
                    }
                    //Close
                    sr.Close();
                    sw.Close();
                }
                //Catching exception
                catch (Exception e)
                {
                    //Exception Message
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
            finally
            {
                Console.WriteLine("Exception finally block.");
            }
