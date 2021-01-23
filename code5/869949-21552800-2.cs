    class robot
    {
          Configuratie config = new Configuratie();
    
          short[,] AlleCoordinaten = new short[3, 6];
          for (int i = 0; i < 3; i++)
          {
             for (int j = 0; j < 6; j++)
             {
                  AlleCoordinaten[i, j] = GetPositionValue("position" + (i+1), j);
             }
          }
        
    }
