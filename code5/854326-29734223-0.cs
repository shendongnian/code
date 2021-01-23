    class Program
    {
        static void Main(string[] args)
        {
            DrawingObject obj1=new Circle(Color.Black, 10);
            DrawingObject obj2=obj1.Clone();
        }
    }
