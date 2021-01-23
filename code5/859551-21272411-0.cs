    [WebMethod]
    public double RoadTax(int engineCapacity, int vehicleAge)
    {
        if (engineCapacity.Equals("600") && vehicleAge.Equals("12"))
        {
            return ((200.00 * 0.782) * (1.10));
        }
    
        return 0d;
    }
