    public class Map
    {
      private int[,] _map;
      
      public Map(int rows, int columns)
      {
        // rows, columns validation here
        _map = new int[rows, columns];
      }
    
      public int this[int r, int c]
      {
        get { return _map[r,c]; }
        set { _map[r,c] = value; }
      }
    }
