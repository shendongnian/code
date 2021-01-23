    foreach (DictionaryEntry entry in alreadyPost)
                {
                    WritePostedAlready.WriteLine(entry.Key + " = " + entry.Value);
                }
                WritePostedAlready.Close();
    
                alreadyPost = new Hashtable();
                List<string> readLines = File.ReadAllLines(@"c:\Temp\WritePostedAlready.txt").ToList();
                foreach (string line in readLines)
                {
                    string key = line.Split('=')[0];
                    string val = line.Split('=')[1];
                    if (!alreadyPost.ContainsKey(key))
                    {
                        alreadyPost.Add(key, val);
                    }
                }
