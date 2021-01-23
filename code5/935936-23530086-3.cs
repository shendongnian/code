    class Student
    {
        public int ID { get; set; } 
        public string Name { get; set; }
        public int Age { get; set; }
        public override bool Equals(object obj)
        {
            return this.ID.Equals(((Student)obj).ID);
        }
        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }
    }
