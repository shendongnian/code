    private InArgument<string> text = "All";
    [RequiredArgument]
    public InArgument<string> Text
    {
        get { return text ?? "All"; }
        set { text = value; }
    }
