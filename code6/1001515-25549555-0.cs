    public void DoSomething(CopyFlag flag)
    {
       if (flag.HasFlag(CopyFlags.PropertiesOnly) && flag.HasFlag(CopyFlags.FieldsOnly))
          throw new ArgumentException();
    
    }
