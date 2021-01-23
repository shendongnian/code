    class Changeable
    {
        public int Prop { get; set; }
        public override int GetHashCode()
        {
            return Prop;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Changeable);
        }
        public bool Equals(Changeable other)
        {
            if (other == null)
                return false;
            return GetType() == other.GetType() && Prop == other.Prop;
        }
    }
