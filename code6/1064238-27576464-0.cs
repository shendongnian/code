                int counter = 0;
                string line;
    
                // Read the file and display it line by line.
                System.IO.StreamReader file =
                   new System.IO.StreamReader("c:\\Intel\\times.txt");
                DateTime lineTime;
                DateTime lastTime = DateTime.MinValue;
                TimeSpan lastTimeToCompare;
    
                while ((line = file.ReadLine()) != null)
                {
                    line = line.Substring(0, line.IndexOf(" ", 12));
                    DateTime.TryParse(line, out lineTime);
                    if (lastTime == DateTime.MinValue)
                    {
                        counter++;
                        lastTime = lineTime;
                    }
                    else
                    {
                        var mins = lineTime.Subtract(lastTime).Minutes;
                        if (mins > 5)
                        {
                            Console.WriteLine(line);
                        }
                        counter++;
                        lastTime = lineTime;
                    }
                }
    
                file.Close();
    
                // Suspend the screen.
                Console.ReadLine();
