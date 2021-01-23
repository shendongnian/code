    class Rectangle
    {
        double length;
        double width;
        double a;
        public void GetValues()
        {
            length = double.Parse(Console.ReadLine());
            width = double.Parse(Console.ReadLine());
        }
        public void Acceptdetails()
        {
        }
        public double GetArea()
        {
            return length * width;
        }
        public void Display()
        {
            Console.WriteLine("Length: {0}", length);
            Console.WriteLine("Width: {0}", width);
            Console.WriteLine("Area: {0}", GetArea());
        }
    }
    class ExecuteRectangle
    {
        public static void Main(string[] args)
        {
            Rectangle r = new Rectangle();
            r.GetValues();
            r.Display();
            Console.ReadLine();
        }
    }
