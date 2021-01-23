    public class BagWithLock
    {
        private volatile object data;
        public object Data
        {
            get { lock return data; }
            set { data = value;  }
        }
        public bool IsEquivalentTo(BagWithLock other)
        {
            return object.Equals(data, other.data);
        }
    }
