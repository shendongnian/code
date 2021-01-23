    Dictionary<string, string> addressTypeDictionary = new Dictionary<string, string>();
    
    foreach (string value in theCustomerData.Select(c => c.AddressType).Distinct())
    {
        string addressTypeId = InsertAddressType(value);
        addressTypeDictionary.Add(addressTypeId, value);
    }
    
    return addressTypeDictionary;
    
    ...
    
    private string InsertAddressType(string value)
    {
        // read up on SQL Injection and do this safely
        using (var newCustConnection = new SqlConnection(...))
        using (var insertAddressType = new SqlCommand("Insert into AddressType Values (@addressTypeValue); Select SCOPE_IDENTITY();", 
        newCustConnection))
        {
            // set parameter value first
            return insertAddressType.ExecuteScalar().ToString();
        }
    }
