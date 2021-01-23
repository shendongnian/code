    class Test
    {
      private static void Stack()
      {
        Console.WriteLine("stack");
      }
    
      private static void Main(string[] arg)
      {
        Dictionary<string, Action> dic = new Dictionary<string, Action>();
    
        dic.Add("stack", () => Stack());
    
        dic["stack"]();
      }
    }
