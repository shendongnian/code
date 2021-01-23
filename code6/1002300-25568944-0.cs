    public struct MyKey
    {
        public readonly int Improd;
        public readonly int Pplist;
        public MyKey(int improd, int pplist)
        {
            Improd = improd;
            Pplist = pplist;
        }
        public override int GetHashCode()
        {
            return Improd.GetHashCode() ^ Pplist.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (!(obj is MyKey)) return false;
            var other = (MyKey)obj;
            return other.Improd.Equals(this.Improd) && other.Pplist.Equals(this.Pplist);
        }
    }
