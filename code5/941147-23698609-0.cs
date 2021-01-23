    public void Handle<T>(T input)
    {
       if (typeof(T) == typeof(string))
       {
            stringHandler.Handle(input);
       }
       else if (typeof(T) == typeof(byte[]))
       {
            byteArrayHandler.Handle(input);
       }
       else
       {
            throw new ApplicationException(string.Format("Unsupported type: {0}",typeof(T));
       }
    }
