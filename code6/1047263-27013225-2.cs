    public static void TestMethod<T>(IEnumerable<T> collection)
    {
       foreach(var item in collection)
       {
    	  Console.WriteLine(item);
       }
    }
