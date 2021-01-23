    public class Dog
    {        
        public Dog(string name) : base ( name, 4) { } 
        //OR this
        public Dog(string name, int legs = 4) : base ( name, legs) { }
    }
