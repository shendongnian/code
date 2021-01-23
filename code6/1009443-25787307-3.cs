    public struct Key
    {
        public string Name { get; }
        public int Rating { get; }
        public Key(string name, int rating)
        {
            this.Name = name;
            this.Rating = rating;
        }
    }
