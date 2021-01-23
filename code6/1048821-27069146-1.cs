    class Table1Comparer : IEqualityComparer<Table1>
    {
        public bool Equals(Table1 x, Table1 y)
        {
            return x.Column1 == y.Column1
                && x.Column2 == y.Column2
                && x.Column3 == y.Column3
                && x.Column4 == y.Column4
                && x.Column5 == y.Column5
                && x.Column6 == y.Column6;
        }
        public int GetHashCode(Table1 obj)
        {
            return obj.GetHashCode();
        }
    }
