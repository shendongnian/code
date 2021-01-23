    string Number;
    
    if (Regex.Match(number, "\d{9}"))
    {
        // Number has 9 digits
    }
    if (Regex.Match(number, "^\d{9}$"))
    {
        // Number is 9 digits only
    }
