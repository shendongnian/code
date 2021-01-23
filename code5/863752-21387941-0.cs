    public Tuple<Type, object> NullCoalesce<TA, TB>(TA a, TB b)
    {
        ...
        else if (a is TB) // pseudocode alert, this won't work in actual C#
        {
            Type type = typeof(TB);
            object result;
            if (a != null)
            {
                result = (TB)a; // in your example, this resolves to null
            }
            else
            {
                result = b;
            }
            return new Tuple<Type, object>(type, result);
        }
        ...
    }
