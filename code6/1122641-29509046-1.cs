    public string SearchText
    {
        get { return TypedText; }
        set { TypedText = value; SetProperty(ref TypedText, value); } 
    }
...  
    private void MyCommandExecuted(string text)
    {
        SearchText = string.Empty;
    }
