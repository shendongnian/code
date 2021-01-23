    class Program
    {
    static void Main(string[] args)
    {
        SortedDictionary<int, int> dict = new SortedDictionary<int, int>();
        dict.Add(4, 40);
        dict.Add(1, 290);
        dict.Add(86, 7);
    
        Console.WriteLine("Sorted Dictionary Items sorted by Key");
        foreach (var v in dict)
        {
    	Console.WriteLine("Key = {0} and Value = {1}", v.Key, v.Value);
        }
    
        Console.WriteLine("------------------------\n");
        Console.WriteLine("Sorted Dictionary Items sorted by Value");
        var SortedByValueDict = dict.OrderBy(item => item.Value);
    
        foreach (var v in SortedByValueDict)
        {
    	Console.WriteLine("Key = {0} and Value = {1}", v.Key, v.Value);
        }
    }
    }
