    string order = "Tumbler (ID: AGST, Quantity: 1, Points each: 2)";
    var keyValues = new List<KeyValuePair<string, string>>();
    int index = order.IndexOf('(');
    if(index++ >= 0)
    {
        int endIndex = order.IndexOf(')', index);
        if(endIndex >= 0)
        {
            string inBrackets = order.Substring(index, endIndex - index);
            string[] tokens = inBrackets.Trim().Split(new[]{','}, StringSplitOptions.RemoveEmptyEntries);
            
            foreach(string token in tokens)
            {
                string[] keyVals = token.Trim().Split(new[]{':'}, StringSplitOptions.RemoveEmptyEntries);
                if(keyVals.Length == 2)
                {
                    keyValues.Add(new KeyValuePair<string,string>(keyVals[0].Trim(), keyVals[1].Trim()));
                }
            }
        }
    }
    foreach (var keyVal in keyValues)
    {
        Console.WriteLine("{0} {1}", keyVal.Key, keyVal.Value);
    }
