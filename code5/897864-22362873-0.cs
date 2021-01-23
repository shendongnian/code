    public void DrawSquare(int sideLength)
    {
      for(int row = 1; row <= sideLength; row++)
      {
         for (int col = 1; col <= sideLength; col++)
         {
           if (col <= row) 
             Console.Write('*');
           else
             Console.Write('#');
         }
         Console.WriteLine();
      }
    }
