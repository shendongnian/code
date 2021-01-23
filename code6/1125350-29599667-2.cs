    void Main()
    {
        var number = 32445.324777M;
    
        string.Format(new MyNumberFormatter(),  "{0:MyG}", number).Dump();
    }
    
    class MyNumberFormatter : IFormatProvider, ICustomFormatter
    {
      public object GetFormat(Type type)
      {
        return this;
      }
      
      public string Format(string fmt, object arg, IFormatProvider formatProvider)
      {
        if (fmt != "MyG" || !(arg is decimal)) return string.Format(CultureInfo.CurrentCulture, "{0:" + fmt + "}", arg);
        
        return "Hi";
      }
    }
