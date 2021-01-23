    public static class Extensions
    {    
       public static string ToCurrency(this decimal number)
       {
           return number.ToString("{0:#,###0.00}") + " (USD)";
       }
    }
