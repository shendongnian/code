    public ActionResult Index()
    {
            List<SalesOrder> SalesOrder = callSalesOrderUSP.ToList();
            List<SalesOrderLines> SalesOrderLines = new List<SalesOrderLines>();
            
            foreach (var thing in SalesOrder)
            {
                SalesOrderLines.AddRange(callSalesOrderLinesUSP(thing.SOKey).ToList());
            }
    
            SalesOrderModel salesOrderModel = new SalesOrderModel
            {
                SOHeader = SalesOrder,
                SOLines = SalesOrderLines
            };
    
    
    
            return View(salesOrderModel);
    }
