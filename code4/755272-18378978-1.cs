    class Test
    {
      private static void Stack(int n)
      {
        Console.WriteLine("stack " + n);
      }
    
      private static void Main(string[] arg)
      {
        Dictionary<string, Action<int>> dic = new Dictionary<string, Action<int>>();
    
        dic.Add("stack", (n) => Stack(n));
    
        dic["stack"](10);
      }
    }
