    class Dog : Mammal
    {
        public Dog()
        {
        }
        public Dog(Mammal other)
        {
           this.Name = other.Name;
           this.Age = other.Age;
           this.Teeth = other.Teeth;
        } 
        public override string ToString()
        {
           return string.Format("{0}, {1}, {2}", 
                   this.Name, this.Age, this.Teeth);
        }
    }
