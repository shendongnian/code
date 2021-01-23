      unsafe { 
        Double[] a = { 1.0, 2.0, 3.0, 4.0, 5.0 };
        fixed (double* aP = a) {
          for (int i = 0; i < a.Length; i++) {
            System.Console.WriteLine(*aP + i);
          }
        }
      }
