    public class Cat : Animal // note you probably mistyped "class" here
    {
        public int AmountOfTeeth { get; set; }
        public override string ToString()
        {
            return Name + " has " + AmountOfTeeth + " teeth"
        }
    }
