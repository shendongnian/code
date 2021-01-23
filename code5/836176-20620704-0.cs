    public class Map
    {
      public Point this[x, y, i]
      {
        get { return this.Chunks[i].Points[x, y, i]; }
      }
    }
