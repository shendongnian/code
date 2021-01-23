    button.Click += async (sender, event) =>
    {
        try
        {
           throw new Exception("button exception");
        }
        catch(Exception ex)
        {
        }
    };
