     public WebService1()
        {
            using (var reader = new StreamReader(File.OpenRead(@"C:/dictionary.csv")))
            {
                while (!reader.EndOfStream)
                {
                    string[] tokens = reader.ReadLine().Split(',');
                    _dictionary[tokens[0]] = tokens[1];
                }
            }
        }
  
