    class BMI
    {
        public string NewName { get; set; }
        public int NewAge { get; protected set; }
        public BMI()
            : this("", 0)
        { }
        public BMI(string name, int age)
        {
            NewName = name;
            NewAge = age;
        }
    }
