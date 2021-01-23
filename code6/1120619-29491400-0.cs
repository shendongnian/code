     public static class DecimalExtension
      {
        public static string MyFormat(this decimal value)
        {
           decimal rounded = Math.Round(value, 4);
           if ((rounded % 1) == 0)
           {
             return rounded.ToString("0:0");
           }
            return rounded.ToString("0:0.0000");
    
          }
      }
