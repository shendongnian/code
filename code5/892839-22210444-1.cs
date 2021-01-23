    public Action Index()
    {
        MyModel model = new MyModel();
        model.SalesOrders.AddRange(CallUspSalesOrder());
        foreach (SalesOrder salesOrder in model.SalesOrders)
        {
            salesOrder.SalesOrderLines.AddRange(CallUspSalesOrderLines(salesOrder.SOKey));
        }
    
        return View(model);
    }
