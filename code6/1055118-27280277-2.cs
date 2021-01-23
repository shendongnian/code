    public static string ToNoneString(this Bar bar)
    {
        if (bar != null && !string.IsNullOrEmpty(bar.Name))
        {
            return bar.Name;
        }
        else 
        {
            return "None";
        }
    }
