    private void printDictionary(IDictionary<string, IEnumerable<Employee>>                                                             InputDictionaryParm1)
    {
        foreach (var a in InputDictionaryParm1)
        {
            Console.WriteLine(a.Key);
            foreach (var e in a.Value)
            {
                Console.WriteLine("\t" + e.Name);
            }
        }
        Console.ReadKey();
    }
