    enum Direction
    {
        Left = 0,
        Up,
        Down,
        Right
    }
    public static void DoSomethingIfDirection(object item)
    {
        if (item != null)
        {
            Type type = item.GetType();
            if (type.IsEnum && typeof(Direction).IsAssignableFrom(type))
            {
                // Do something
                Console.WriteLine((Direction)item);
            }
        }
    }
    public static void Main(params string[] args)
    {
        DoSomethingIfDirection("Hello");
        DoSomethingIfDirection("Left");
        DoSomethingIfDirection(Direction.Left);
    }
