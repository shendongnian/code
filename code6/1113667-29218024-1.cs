    public async Task<ActionResult> Index()
    {
        var mobileClient = new MobileServiceClient("Your mobile service URL",
                                                   "Your mobile service access key");
        var itemModelTable = mobileClient.GetTable<ItemModel>();
        var result= await itemModelTable.ToListAsync();
        return View(result);
      }
