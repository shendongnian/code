    public static void Demo()
    {
        var outer = new Outer {
            OX = 1,
            OI = new[] {new Inner {IX = 2, IY = "two"}, new Inner {IX = 3, IY = "three"}}
        };
        var doc = SerializeOuter(outer);
        Console.WriteLine(doc.ToString());
    }
