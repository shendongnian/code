    // a public property is not necessary for this
    bool HasText
    {
        get 
        {
            return !string.IsNullOrEmpty(textBox1.Text);
        }
    }
    ...
    if (HasText)
    {
        
    }
