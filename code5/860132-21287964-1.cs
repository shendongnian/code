    public static void Terros(int n) {
      Console.Write("Terros generated :");
      int t = n;
      int i = 1;
      Console.Write(" " + t);
      while (t > 1) {
        int tm1 = t;
        if (i%2 == 0) {
          t = tm1/2;
        }
        else {
          t = (3*tm1+1)/2;
        }
        Console.Write(", " + t);
        i++;
      }
      Console.WriteLine("");
    }
    
