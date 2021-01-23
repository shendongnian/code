    public T ReadData<T>(int startIndex)
    {
      Type t = typeof(T);
      if (t == typeof(int))
      {
        return ReadInt(startIndex);
      }
      else if(t == typeof(byte))
      {
        return ReadByte(startIndex);
      }
      else
      {
        string err = string.Format("Please support the type {0}", t);
        throw new NotSupportedException(err);
      }
    }
