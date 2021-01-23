    public static void Main()
    {
       var array1 = Enumerable.Range(0, 100).Select(x => x.ToString()).ToArray();
       var array2 = Enumerable.Range(0, 100).Select(x => x.ToString()).ToArray();
    
       System.Console.WriteLine(AreArraysEqual(array1 , array2).ToString());
    }
    public bool AreArraysEqual(string[] array1, string[] array2) 
    {
       return array1.SequenceEqual(array2);
    }
