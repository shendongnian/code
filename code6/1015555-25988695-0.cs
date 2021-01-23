    if (txtboxNo.Text.IndexOf(".") >= 0) 
    {
        // double or decimal
        if (txtboxNo.text.length >= 17)
        {
            // Possible decimal as too long for double
            Decimal mydec;
            if (Decimal.TryParse(txtboxNo.Text, out mydec))
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
           if (Double.TryParse(txtboxNo.Text, out mydoub))
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
        if (int.TryParse(txtboxNo.Text, out myInt))
        { 
            // its an int
        }
        else
        {
            // something else
        }
    }
