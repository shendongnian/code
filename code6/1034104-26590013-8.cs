    public bool InPossession
    {
        get { return _inPossession; }
        set { _inPossion = value; RaisePropertyChanged("InPossession"); }
    }
    private void LoadCloakroomOrders()
    {
        CloakroomOrderRepository repo = new CloakroomOrderRepository();
        //Get All orders
        var orders = repo.GetPublic();
        foreach (var orderItem in orders)
        {
            Orders.Add(orderItem);
            if (orderItem.InPossesion == false)
            {
                InPossession = false;
            }
        }
    }
