    public ActionResult Create(CreditCard model)
    {
        using(EntitiesContext context = new EntitiesContext()) // using keyword will dispose the object properly.
        {
            int uid = (int)WebSecurity.GetUserId(User.Identity.Name);  // Currently logged-in user
            short? maxccid = 0; //this will be the max ccid for this user
            var query = from c in context.CreditCards 
                    where c.UserId == uid && c.CCID == (context.CreditCards.Max(c1 => c1.CCID) ) select c.CCID ;
            maxccid = query.Max() ?? 0; //use null-coalescing operator.
        }
    }
