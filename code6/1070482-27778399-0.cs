    if(char.IsDigit(postcodeID.ToString()[1]))
    {
        query = customerList.Where(c => char.IsDigit(c.Postcode[1]));
    }
    else 
    {
        query = customerList.Where(c => !char.IsDigit(c.Postcode[1]));
    }
