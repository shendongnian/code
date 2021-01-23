       public class Ship: ICloneable
        {
            public Vector3 ShipPosition;
            public ShipType Type;
            public string DesignName;
            public Ship(ShipType type, string designame)
            {
                Type = type;
                DesignName = designame;
                ShipPosition = Vector3.zero;
            }
            public object Clone()
            {
               return this.MemberwiseClone();
            }
        }
