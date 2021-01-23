    public interface IClassInfo
    {
        int FieldCount { get; }
    }
    abstract class Base : IClassInfo
    {
        protected virtual int GetFieldCount()
        {
            return -1;
        }
    
        public int FieldCount { get { return GetFieldCount(); } }
    }
    class Node : Base
    {
        int x, y, z; // has three fields, so:
        protected override int GetFieldCount()
        {
            return 3;
        }
    }
    class Way : Base
    {
        int w, x, y, z; // has four fields, so:
        protected override int GetFieldCount()
        {
            return 4;
        }
    }
  
