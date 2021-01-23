     public GiftController()
     {
         var context = new ApplicationDbContext();
         this._giftRepository = new GiftRepository(context);
         this._accountRepository = new AccountRepository(context);
     }
