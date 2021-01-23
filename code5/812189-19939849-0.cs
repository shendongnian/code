    public string Foo(IFormattable text)
    {
        Foo(text.ToString());
    }
    public string Foo(string text)
    {
        // do stuff with text and
        // return processed string
    }
