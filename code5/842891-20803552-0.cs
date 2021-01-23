    public abstract class UnitBase
    {
        public int Cost { get; private set; }
    
        public UnitBase(int cost)
        {
            this.Cost = cost;
        }
    }
