    [Route("api/Deliveries")] 
    public Delivery GetDeliveryById(int ID)
    {
        return _deliveryRepository.GetById(ID);
    }
    [Route("api/Deliveries")] 
    public IEnumerable<Delivery> GetBatchOfDeliveriesByStartingID(int ID, int CountToFetch)
    {
        return _deliveryRepository.GetRange(ID, CountToFetch);
    }
