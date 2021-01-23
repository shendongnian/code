    public static void RemoveRecord(ZipCodeTerritory zipCode)
    {
        using(var _newdb = new AgentResources())
        {
            ZipCodeTerritory zipCodeRemove = new ZipCodeTerritory();
            zipCodeRemove.channelCode = zipCode.channelCode;
            zipCodeRemove.stateCode = zipCode.stateCode;
            zipCodeRemove.zipCode= zipCode.zipCode;
            zipCodeRemove.endDate = zipCode.endDate;
            _newdb.ZipCodeTerritory.Attach(zipCodeRemove);
            _newdb.ZipCodeTerritory.Remove(zipCodeRemove);
            //((IObjectContextAdapter)_newdb).ObjectContext.Refresh(
                                                        // RefreshMode.ClientWins
                                                        //, zipCode);
            _newdb.SaveChanges();
        }
    }
