    private void PrintValues(Dictionary<string, Domain> dict)
    {
        foreach(KeyValuePair<string, Domain> kvp in dict)
        {
            Console.WriteLine(kvp.Key); //Key
            Console.WriteLine(kvp.Value.ToString()); //Value
        }
    }
    //Usage:
    PrintValues(SharedToDomains);
    PrintValues(SharedFromDomains);
