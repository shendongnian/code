    public class Shapes
    {
        protected readonly int sides;
        public int NumberOfSides { get { return sides; } } 
    }
    public class Triangle : Shapes
    {
        public Triangle()
        {
            this.sides = 3;
        }
    }
    
    public class Square : Shapes
    {
        public Square()
        {
            this.sides = 4;
        }
    }
