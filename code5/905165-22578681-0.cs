     void throw()
        {
          
          Random r = new Random();
          for (int i = 0; i <dice.GetLength(0); i++)
            {
                int totalSum = 0;
                for (int j  = 0; j < dice.GetLength(1); j++)
                {
                    dice[i, j] = r.Next(1, _yChoice);
                    totalSum += dice[i, j];
                }
                // Here you display totalSum for game with index i.
            }
    
      }
