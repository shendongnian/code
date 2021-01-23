    List<string> myAppendedList = new List<string>();
    using (StreamReader sr = new StreamReader(@"C:\abc.txt"))
    {
        string line;
        line = sr.ReadLine();
        while (line != null)
        {
            if (line.StartsWith("<"))
            {
                if (line.IndexOf('{') == 29)
                {
                    string s = line;
                    int start = s.IndexOf("{");
                    int end = s.IndexOf("}");
                    string result = s.Substring(start + 1, end - start - 1);
                    Guid g = Guid.NewGuid();
                    line = line.Replace(result, g.ToString());
                    myAppendedList.Add(line);
                }
            }
            Console.WriteLine(line);
            line = sr.ReadLine();
        }
    }
    if(myAppendedList.Count > 0 )
        File.WriteAllLines(@"C:\abc.txt", myAppendedList);
