    class DataComparer : IEqualityComparer<Data>
    {
        public bool Equals(Data x, Data y)
        {
            //logic to compare x to y and return true when they are equal
        }
        public int GetHashCode(Data d)
        {
            //logic to return a hash code
        }
    }
    class InfoComparer : IEqualityComparer<Info>
    {
        public bool Equals(Info x, Info y)
        {
            //logic to compare x to y and return true when they are equal
        }
        public int GetHashCode(Info i)
        {
            //logic to return a hash code
        }
    }
