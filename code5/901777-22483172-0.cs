    private bool CheckSync(var customerAddresses, var addressModel)
    {
        foreach(var item in customerAddresses)
        {
            if(item.Id != addressModel.Id 
            || !item.Street.Equals(addressModel.Street, StringComparison.OrdinalIgnoreCase)
            || !item.City.Equals(addressModel.City, StringComparison.OrdinalIgnoreCase)
            || !item.Province.Equals(addressModel.Province, StringComparison.OrdinalIgnoreCase)
            || !item.PostalCode.Equals(addressModel.PostalCode, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
        }
        
        return true;
    }
