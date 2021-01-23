    public override bool Equals(System.Object obj)
        {
            if (obj == null) { return false; }
            Account m = obj as Manager;
            if ((System.Object)m == null) { return false; }
            return (ID == m.ID);
        }
    
        public bool Equals(Manager m)
        {
            if ((object)m == null) { return false; }
            return (ID == m.ID);
        }
    
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
