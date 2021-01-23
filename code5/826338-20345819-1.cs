    class Program {      
      static void Main(string[] args) {
        String ss = "1,2,3";
        String search = "2";
    
        Console.WriteLine(ss.Split(',').Contains(search) ? "true" : "false");
      }
    }
