    class University
    {
        public Faculty Faculty { get; set; }
        public University()
        {
            Faculty = new Faculty();
        }
    }
    class Faculty
    {
        public string Name { get; set; }
        public Faculty()
        {
            Name = "MIT";
        }
    }
