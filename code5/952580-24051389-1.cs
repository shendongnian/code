    // For educational purposes only!!!
    public class Polygon
    {
        public static Polygon Create(int sides) 
        {
            switch (sides)
            {
            case 3:
                return new Triangle();
            // ...
            default: 
                throw new ArgumentOutOfRangeException(/*...*/);
            }
        }
    }
    var shape = Polygon.Create(3);
    var isTriangle = shape is Triangle;
