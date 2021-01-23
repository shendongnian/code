    class Rate
    {
        public string Id { get; private set; }
        public decimal Value { get; private set; }
        public DateTime Date { get; private set; }
        // let's make the class immutable
        public Rate(string id, decimal value, DateTime date)
        {
            Id = id;
            Value = value;
            Date = date;
        }
    }
