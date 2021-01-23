     struct Point 
     {
          private int fieldX;
          private int fieldY;
          public Point(int x, int y) 
          {
              fieldX = x;
              fieldY = y;
          }
          public int X 
          {
             get {  return fieldX; }
          }
          public int Y
          {
             get {  return fieldY; }
          }
     }
