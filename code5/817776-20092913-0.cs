    public class Building
    {
        public virtual int CellCount { get { return 5; } }
    }
    public class Room : Building
    {
        public override int CellCount { get { return 6; } }
    }
