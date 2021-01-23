    class Shape
    {
        Color Color { get; set; }
    }
    class Rectangle : Shape
    {
        double SideA { get; set; }
        double SideB { get; set; }
    }
    class Square : Rectangle
    {
    }
