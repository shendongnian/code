                static int[] data()
                {
    		        List<int> database = new List<int>();
                    StreamReader house = new StreamReader("text.txt");
                    while (!house.EndOfStream)
                    {
                        s = house.ReadLine();
                        Console.WriteLine(s);
                    
                        string[] data1 = s.Split(' ');
                        for (int j = 0; j < data1.Length; j++)
                        {    
                            int value;
                            if (Int32.TryParse(data1[j], out value))
                                database.Add(value));
                        }		
                    }
                    return database.ToArray();
                }
