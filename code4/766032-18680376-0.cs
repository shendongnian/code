    Dictionary<Int32, List<String>> dt = new Dictionary<Int32, List<String>>();           
                int eventsize;
                StreamReader sr = new StreamReader("Bluegene.log");           
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    eventsize = s.Length - 9; //size of only the message field      
                    if (!dt.ContainsKey(eventsize))
                    {
                        List<String> entries = new List<String>();
                        entries.Add(s);
                        dt.Add(eventsize, entries);
                    }
                    else
                    {
                        dt[eventsize].Add(s);
                    }
                }
