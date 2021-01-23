    [WebMethod]
    public static int SaveManualEntry(string Geo, int GeoId, string CountryCode,
                                      string Segment, string SubsegmentID, 
                                      List<OrderDetail> OrderDetails)
    {
    
        try
        {
            int TotalOrderCount = 0;
            int Successcount = 0;               
            return Successcount;
    
        }
        catch (Exception ex)
        {
            throw ex;
        }
    
    }
