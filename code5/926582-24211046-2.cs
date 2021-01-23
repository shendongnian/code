    public class First
    {
        public Second Second { get; set; }
        public int id { get; set; }
        public First(){}
        public First(bool init)
        {
            this.id = 1;
            this.Second = new Second();
        }
    }
    public class Second
    {
        public Third Third { get; set; }
        public int id { get; set; }
        public Second()
        {
            this.id = 1;
            this.Third = new Third();
        }
    }
    public class Third
    {
        public int id { get; set; }
        public Third()
        {
            this.id = 1;
        }
    }
