    struct X: IComparable<X> {
        public int ID;
        public int StopOrder;
        public int CompareTo (X other) {
            return ID.CompareTo(other.ID);
        }
    }
