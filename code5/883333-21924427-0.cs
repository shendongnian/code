    //passing myDictionary to this function
    static public void function2(Dictionary<string, string> myDictionary)
    {
        foreach (var v in myDictionary)
            Console.WriteLine(string.Format("{0}: {1}", v.Key, v.Value));
    }
