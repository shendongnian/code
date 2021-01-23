    class Person
    {
        string FirstName { get; set; }
        int Age { get; set; }
        public override string ToString()
        {
            return this.FirstName + ":" + this.Age;
        }
    }
