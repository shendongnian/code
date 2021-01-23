    public BusAcntController() : this(new BusAcntService(), new MyDb())
    { 
    } 
    public BusAcntController(IBusAcntService busAcntService, MyDb db)
    { 
        _busAcntService = busAcntService;
        _db = db;  
    }
