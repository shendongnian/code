    public static void GenericTester()
    {
        var input = "cbr=LACbtn,detnumber=1232700,laclvetype=ANN,laccalcrun=2014-09-10,lacbutton=Y,lacaccdays=0.00000000,lacentdate=2014-03-31,lactotdays=32.00,laclastent=2014-04-01,lacsrvdays=363,status=ok";
        var keyValuePairs = input.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
    
        var inputKeysAndValues = new Dictionary<string, string>();
    
        foreach (var keyValuePair in keyValuePairs)
        {
            var equalsPos = keyValuePair.IndexOf('=');
    
            // If there was no '=' or it was the last character, assign empty string
            if (equalsPos == -1 || equalsPos == keyValuePair.Length - 1)
            {
                inputKeysAndValues[keyValuePair] = string.Empty;
            }
            // Otherwise, if the '=' was not the first character, assign the value to the key
            else if (equalsPos > 0 && keyValuePair.Length > equalsPos + 1)
            {
                inputKeysAndValues[keyValuePair.Substring(0, equalsPos)] = keyValuePair.Substring(equalsPos + 1);
            }
        }
    
        foreach (var inputKeyAndValue in inputKeysAndValues)
        {
            Console.WriteLine("{0} = {1}", inputKeyAndValue.Key, inputKeyAndValue.Value);
        }
    }
