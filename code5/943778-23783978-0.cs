    public static ObjectB ObjectAConverter(ObjectA a)
    {
        var b = new ObjectB();
        b.Prop1 = a.Prop1;
        b.Prop2 = a.Prop2;
        return b;
    }
