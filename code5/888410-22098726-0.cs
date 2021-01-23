    public bool UpdateSpotCheckInventory(SpotCheck transferObject)
    {
        bool blnUpdated = false;
        try
        {
            blnUpdated = SpotCheckCollectionGateway.UpdateData(transferObject);
            LogMessage.WriteEventLog("SpotCheck records updated successfully", "Ryder.ShopProcessService.SOA", 3, null);
            return blnUpdated;
        }
        catch (Exception ex)
        {
            //throw fault exception here on service
            Throw New FaultException("A fatal exception occurred while processing your request", New FaultCode("1000"))
        }
    }
