    private string processTextData( string value)
    {
        double temp;
        if (double.TryParse(value, out temp))
        {
            return Convert.ToString(Math.Sqrt(temp));
        }
        else
        {
            return value + " is not a number";
        }
    }
