    [Obsolete("Use the Text property, or I break your legs; fair warning")]
    private string text;
    public string Text
    {
    #pragma warning disable 0618
        get { return text; }
        private set
        {
            // some actions with a value
            value = value.Replace('a', 'b');
            text = value;
        }
    #pragma warning restore 0618
    }
