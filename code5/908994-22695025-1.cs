    struct GroupKey
    {
        public GroupKey(decimal _id1,decimal _id2):this()
        {
            Id1= _id1;
            Id2= _id2;
        }
        public decimal Id1{ get; private set; }
        public decimal Id2{ get; private set; }
    } 
