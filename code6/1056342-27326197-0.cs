    for(int i = 0; i<pattern.GetLength(0); i++) 
    {
         for(int j=0; j<pattern.GetLength(1); j++)
         {
              pattern[i,j] = gen.Next(0,5);
         }
    }
