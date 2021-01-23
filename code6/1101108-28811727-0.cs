    Dictionary<string, Dictionary<string, string>> myDictionary = new Dictionary<string, Dictionary<string, string>>();
    
                Dictionary<String, string> di = new Dictionary<string, string>();
                di.Add("1", "Hello1");
                myDictionary.Add("Item1", di);
    
                di.Add("2", "Hello2");
                myDictionary.Add("Item2", di);
    
                di.Add("3", "Hello3");
                myDictionary.Add("Item3", di);
    
    
                var result = myDictionary.Where(c => c.Key == "Item1").FirstOrDefault();
                if (result.Key != null)
                {
                    Dictionary<string, string> output = result.Value;
                }
