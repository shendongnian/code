    public void Write<T>(T val) where T : struct
    {
        if (binWriter != null)
        {
            if(typeof(T) == typeof(bool)
                binWriter.Write((bool)val);
            else if(typeof(T) == typeof(byte)
                binWriter.Write((byte)val);
            ..etc
        }
    }
