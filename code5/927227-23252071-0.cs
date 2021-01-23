    public byte[] GetBytes <TSource> (TSource input)
    {
         dynamic obj = input;
         BitConverter.GetBytes(obj);
    }
