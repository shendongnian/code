    if(char.IsDigit(postcodeID.ToString()[1]))
    {
        query = customerList.Where(c => c.Postcode[0] == 'B' &&
                                        char.IsDigit(c.Postcode[1]));
    }
    else 
    {
        query = customerList.Where(c => c.Postcode.StartsWith("BL"));
    }
