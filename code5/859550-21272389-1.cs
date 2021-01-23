    [WebMethod]
    public double RoadTax(int engineCapacity, int vehicleAge)
    {
        double totalroadtax = 0;
    
        if (engineCapacity == 600 && vehicleAge ==12)
        {
            totalroadtax = ((200.00 * 0.782) * (1.10));
        }
    
        return totalroadtax;
    }
