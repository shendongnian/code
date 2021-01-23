    public static string TerritoryOnly(ZipCodeTerritory zipCode, string territory)
    {
        msg = string.Empty;
        using (var db = new AgentResources())
        {
            zipCode.IndDistrnId = territory;
            Save(db, zipCode);                
        }
        return msg;
    }
