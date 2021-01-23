    public static void Foo(Vector<Vector<Vector<IVector>>> vector)
    {
        var first = vector.Value;
        var second = vector.Tail.Value;
        var third = vector.Tail.Tail.Value;
    }
