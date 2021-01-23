    public class Animal
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public virtual string Description
        {
            get { return string.Format("{0} {1}, Color, Name)"); }
        }
    }
    public class Dog : Animal
    {
        public override string Description
        {
            get { return base.Description; }
        }
    }
    public class Cat : Animal
    {
        public override string Description
        {
            get { return "I'm a cat. I'm special."; }
        }
    }
