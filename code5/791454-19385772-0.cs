    void Main()
    {
        string[] inputs =
        {
            "a",
            "z",
            "A test",
            "A TEST",
            "a test"
        };
    
        foreach (var input in inputs)
        {
            var beauty =
                (from c in input
                 let C = char.ToUpper(c)
                 where C >= 'A' && C <= 'Z'
                 select (int)(C - 'A') + 1).Sum();
            beauty.Dump(input);
        }
    }
