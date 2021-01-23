    public string Foo(IFormattable text, string format, IFormatProvider formatProvider)
    {
        return Foo(text.ToString(format, formatProvider));
    }
    public string Foo(IFormattable text, string format)
    {
        return Foo(text.ToString(format, null));
    }
    public string Foo(string text)
    {
        // do stuff with text and
        // return processed string
    }
