    public T ReadData<T>(int startIndex)
    {
      Type t = typeof(T);
      if (t == typeof(int))
      {
        return (T)(object)ReadInt(startIndex);
      }
      else if(t == typeof(byte))
      {
        return (T)(object)ReadByte(startIndex);
      }
      else
      {
        string err = string.Format("Please support the type {0}", t);
        throw new NotSupportedException(err);
      }
    }
