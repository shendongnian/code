    public struct Key
    {
        private readonly string name;
        private readonly int rating;
        public string Name { get { return name; } }
        public int Rating { get { return rating; } }
        public Key(string name, int rating)
        {
            this.name = name;
            this.rating = rating;
        }
    }
