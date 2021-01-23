    string s = "1";
    int? result;
    if (string.IsNullOrEmpty(s))
    {
        result = null;
    }
    else
    {
        int o; // just a temp variable for the `TryParse` call
        if (int.TryParse(s, out o))
        {
            result = o;
        }
        else
        {
            result = null;
        }
    }
    // use result
