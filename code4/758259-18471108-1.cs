    public class ViewModel
    {
    	public IList<Address> Addresses = new List<Address>();
    
    	public void PopulateAddresses()
    	{
    		foreach(DataRow row in AddressTable.Rows)
    		{
    			Address address = new Address
    				{
    					Address1 = row["Address1"].ToString(),
    					CityName = row["CityName"].ToString(),
    					StateCode = row["StateCode"].ToString(),
    					ZipCode = row["ZipCode"].ToString()
    				};
    			Addresses.Add(address);
    		}
    
    		lAddressGeocodeModel.Addresses = JsonConvert.SerializeObject(Addresses);
    	}
    }
