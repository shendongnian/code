    public static MethodBase GetCurrentMethod()
    {
      var sf = new StackFrame(1);
      return sf.GetMethod();
    }
