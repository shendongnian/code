    public string TextProperty
    {
        get
        {
            return selectedText;
        }
        set
        {
            SetProperty(ref selectedText, value, "TextProperty");
        }
    }
