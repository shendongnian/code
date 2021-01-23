    public static void Main()
    {
       var array1 = Enumerable.Range(0, 100).Select(x => x.ToString()).ToArray();
       var array2 = Enumerable.Range(0, 100).Select(x => x.ToString()).ToArray();
    
       bool equal = array1.SequenceEqual(array2);
       Console.WriteLine("The arrays {0} equal.", equal ? "are" : "are not");
    }
 
