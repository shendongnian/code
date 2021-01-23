    public class Standing
    {
        public string Name { get; set; }
        public int Position { get; set; }
        public Standing(string name, int position)
        {
            Name = name;
            Position = position;
        }
        public override string ToString()
        {
            return Position + ": " + Name;
        }
    }
