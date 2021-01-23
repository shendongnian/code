    public class Ship
    {
      public Vector3 ShipPosition;
      public ShipType Type;
      public string DesignName;
      public Ship(ShipType type,string designame)
      {
        Type = type;
        DesignName = designame;
        ShipPosition = Vector3.zero;
      }
      //copy-constructor
      public Ship(other)
      {
        Type = other.Type;
        DesignName = other.DesignName;
        ShipPosition = Vector3.zero;
      }
    }
