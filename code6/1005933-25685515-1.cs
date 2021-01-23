    static void FuncWrap<T>(T val)
    {
        Console.Write("Wrap: ");
        if (val is string)
        {
            Func((string)(object)val);
        }
        else if (val is int)
        {
            Func((int)(object)val);
        }
        else
        {
            Func(val);
        }
    }
