      static void Main(string[] args) {
        ...
        int timesZero = 0;
        
        for (int i = 5; i <= n; i += 5) {
          int term = i;
        
          while ((term % 5) == 0) {
            timesZero += 1;
            term /= 5;
          }
        }
        ...
      }
