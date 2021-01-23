       // If you have special functions implemented (i.e. Erf) 
    
       // outcoume is in [0..inf) range
       public static Double NormalPDF(Double value, Double mean, Double sigma) {
         Double v = (value - mean) / sigma;
    
         return Math.Exp(-v * v / 2.0) / (sigma * Math.Sqrt(Math.PI * 2));
       }
    
       // outcome is in [0..1] range
       public static Double NormalCDF(Double value, Double mean, Double sigma, Boolean isTwoTail) {
         if (isTwoTail)
           value = 1.0 - (1.0 - value) / 2.0;
    
         //TODO: You should have Erf implemented
         return 0.5 + Erf((value - mean) / (Math.Sqrt(2) * sigma)) / 2.0;
       }
