    public static void Main()
    {
       Example e = new Example(height: 64, weight: 123);
    }
    
    public class Example
    {
        int _weight;
        int _height;
    
        public CalculateBMI(int weight, int height)
        {
            _weight= weight;
            _height = height;
        }
    }
