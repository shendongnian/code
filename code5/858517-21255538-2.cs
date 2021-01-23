    protected override void Execute(CodeActivityContext context)
    {
        string text = context.GetValue(this.Text);
        if (text == null) 
        {
            text = "All";
        }
        Console.WriteLine(text);
    }
