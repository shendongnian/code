    if (textBoxValue.IndexOf(".") >= 0) 
    {
        // double or decimal
        if (textBoxValue.length >= 17)
        {
            // Possible decimal as too long for double
            Decimal mydec;
            if (Decimal.TryParse(textBoxValue , out mydec))
            {
               // Is decimal
            }
           else
           {
               // Is something else
           }
        } 
        else
        {
           double mydoub;
           if (Double.TryParse(textBoxValue, out mydoub))
           {
               // Is double
           }
           else
           {
               // Is something else
           }
        }
    }
    else
    {
        int myInt;
        // possible int 
        if (int.TryParse(textBoxValue, out myInt))
        { 
            // its an int
        }
        else
        {
            // something else
        }
    }
