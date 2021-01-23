    public virtual string GetCountryCostName()
    {
        if (Address == null || Address.Region == null || Address.Region.CountryCode == null || Address.Region.CountryCode.CostCode == null)
            return null;
        return Address.Region.CountryCode.CostCode.Name; 
    }
