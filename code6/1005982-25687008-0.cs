    public void SetTextBoxStyle(string attribute, string value)
    {
        textbox.Attributes[attribute] = value;
    }
    public string GetTextBoxStyle(string attribute)
    {
        return textbox.Attributes[attribute];
    }
