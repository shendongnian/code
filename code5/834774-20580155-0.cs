     public Complex readInput()
     {
         Complex temp = 0;
         try
         {
              Console.Write("Enter input: ");
              string input = Console.ReadLine();
    
              String[] cplx= input.Split(' ');
              if (cplx.Length >= x)
              {
                   throw new IndexOutOfRangeException("INVALID INPUT ENTRY...");
              }
    
              temp = new Complex(Double.Parse(cplx[0]), Double.Parse(cplx[1]), ...);
         }
         catch (FormatException)
         {
              Console.WriteLine("INVALID INPUT ENTRY...");
         }
         return temp;
     } 
