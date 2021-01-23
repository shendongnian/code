    public string Eval(string expression, string format)
    {
      object value = Eval(expression);
      return FormatValueInternal(value, format);
    }
    internal static string FormatValueInternal(object value, string format)
    {
      ....
      return String.Format(CultureInfo.CurrentCulture, format, value);
    }
