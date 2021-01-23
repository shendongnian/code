    class Table<TA> : Dictionary<Int, TA>
    {
        public Table(IDictionary<Int, TA> dictionary)
            : base(dictionary)
        {
        }
    }
