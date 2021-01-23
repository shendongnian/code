    //dbcontext
    using (var dbcontext = MyDbContext()) 
    {
    Dictionary<string, string> states = dbcontext .States.ToDictionary(t => t.StateID.ToString(), t => t.StateName.ToString());
    }
    // in controller attach this dictionary to ViewBag:
    ViewBag.States=states;
