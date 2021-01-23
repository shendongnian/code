	    struct User : ICloneable
    {
        public int id;
        public Dictionary<int, double> neg;
        public object Clone()
        {
            var user = new User { neg = new Dictionary<int, double>(neg), id = id };
            return user;
        }
    }
