       public static void Main()
       {
          double[] values = { 2.125, 2.135, 2.145, 3.125, 3.135, 3.145 };
          foreach (double value in values)
             Console.WriteLine("{0} --> {1}", value, Math.Round(value, 2));
    
       }
