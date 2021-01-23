    public bool TryParse(string value, out double output)
    {
        output = 0;
    
        try
        {
            double = double.Parse(value);
        }
        catch (Exception ex)
        {
            return false;
        }
    }
