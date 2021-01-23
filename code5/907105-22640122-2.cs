    [__DynamicallyInvokable]
    public override string ToString()
    {
      return Enum.InternalFormat((RuntimeType) this.GetType(), this.GetValue());
    }
    private static string InternalFormat(RuntimeType eT, object value)
    {
      if (!eT.IsDefined(typeof (FlagsAttribute), false))
        return Enum.GetName((Type) eT, value) ?? value.ToString();
      else
        return Enum.InternalFlagsFormat(eT, value);
    }
