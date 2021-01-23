    public static void RemoveRecord(ZipCodeTerritory zipCode)
    {
        using(var _newdb = new AgentResources())
        {
            _newdb.ZipCodeTerritory.Attach(zipCode);
            _newdb.ZipCodeTerritory.Remove(zipCode);
            _newdb.Refresh(RefreshMode.ClientWins, zipCode)
            _newdb.SaveChanges();
        }
    }
