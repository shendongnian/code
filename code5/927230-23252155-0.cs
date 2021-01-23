    public byte[] GetBytes <TSource> (TSource input)
    {
        var t = typeof(TSource);
        return    (t == typeof(int))  ? BitConverter.GetBytes((int) (object) input)
                : (t == typeof(bool)) ? BitConverter.GetBytes((bool)(object) input)
                : (t == typeof(char)) ? BitConverter.GetBytes((char)(object) input)
                : null;
    }
