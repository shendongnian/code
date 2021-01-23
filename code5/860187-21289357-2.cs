       // I let myselft return the result as Tupple<,>
       public static Tuple<Double, Double> Gauss(Double a0, Double b0, int n) {
          Double prior_a;
          Double prior_b;
    
          Double a = a0;
          Double b = b0;
    
          for (int i = 0; i < n; ++i) {
            prior_a = a;
            prior_b = b;
    
            a = (prior_a + prior_b) / 2.0;
            b = Math.Sqrt(prior_a * prior_b);
          }
    
          return new Tuple<Double, Double>(a, b);
        }
    Simple test: let a0 = 1; b0 = 5, so we have
    
    Theory:
      itt #  a             b
          0  1             5
          1  3             sqrt(5)
          2  (3+sqrt(5))/2 sqrt(3*sqrt(5))
    
    Actual:
    
      Gauss(1, 5, 0);   // returns (1, 5)
      Gauss(1, 5, 1);   // -/-     (3, 2.23606797749979)
      Gauss(1, 5, 2);   // -/-     (2.61803398874989, 2.59002006411135)
      Gauss(1, 5, 3);   // -/-     (2.60402702643062, 2.60398935469938)
      Gauss(1, 5, 10);  // -/-     (2.60400819053094, 2.60400819053094)
      Gauss(1, 5, 100); // -/-     (2.60400819053094, 2.60400819053094)
