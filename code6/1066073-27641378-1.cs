    private static IEnumerable<string> Filter(IEnumerable<string> sequence)
    {
        var bigOnes = sequence.Where (s => s.Length > 3);
        if (true)
        {
            bigOnes = bigOnes.Where (s =>  s.Length % 2 == 0);
        }
        return bigOnes;
    }
...
    var resultThree = Filter(arrayOne);  
    Console.WriteLine(string.Join(", ", resultThree));
    var resultFour = Filter(arrayTwo);
    Console.WriteLine (string.Join(", ", resultFour));
