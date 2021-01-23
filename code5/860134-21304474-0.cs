    public static String TerrosSequence(int n) {
      StringBuilder Sb = new StringBuilder();
     
      // Again: dynamic programming is far better here than recursion
      while (n > 1) {
        if (Sb.Length > 0)
          Sb.Append(",");
    
        Sb.Append(n);
      
        n = (n % 2 == 0) ? n / 2 : (3 * n + 1) / 2;
      }
    
      if (Sb.Length > 0)
        Sb.Append(",");
    
      Sb.Append(n);
    
      return Sb.ToString();
    }
    
    
    // Output: "Terros generated : 5,8,4,2,1"
    Console.WriteLine("Terros generated : " + TerrosSequence(5));
