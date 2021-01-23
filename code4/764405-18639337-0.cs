    [HttpPost]
    public ActionResult Add(Market market)
    {
        [...]
    
        Market marketBasics = new Market
        {
            Name = market.Name,
            Slug = market.Slug,
            Manager = market.ManagerId
        };
    
        [...]
    
        User user = new User
        {
            Id = market.ManagerId
        };
    
        db.User.Attach(user);
        marketBasics.User.Add(user);
        db.Markets.Add(marketBasics);
    
        [...]
    }
