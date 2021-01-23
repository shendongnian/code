    static void FuncWrap<T>(T val)
    {
        Console.Write("Wrap: ");
        if (typeof(T) == typeof(string))
        {
            Func((string)(object)val);
        }
        else if (typeof(T) == typeof(int))
        {
            Func((int)(object)val);
        }
        else
        {
            Func(val);
        }
    }
