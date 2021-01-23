    public class ClassSecond
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public ClassSecond(string name)
        {
            Name = name;
            Height = 100;
            Weight = 100;
        }
        public ClassSecond(string name, int height)
            : this(name)
        {
            Height = height;
        }
        public ClassSecond(string name, int height, int weight)
            : this(name, height)
        {
            Weight = weight;
        }
    }
