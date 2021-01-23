    public ActionResult Index()
    {
        var db = new ApplicationDbContext();    
        var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        var CurrentUser = manager.FindById(User.Identity.GetUserId());
        var loans =
            db.Transaction
              .Where(t =>
                  t.AgentId == CurrentUser.SalesAgent.AgentId)
              .ToList();
        var monthlyTarget =
            db.SalesAgent
              .Where(t =>t.AgentId == CurrentUser.SalesAgent.AgentId)
              .Select(t => (decimal)t.MonthlyTarget)
              .FirstOrDefault();
        var salesAgent = 
            db.SalesAgent
              .FirstOrDefault(s => s.AgentId == CurrentUser.SalesAgent.AgentId);
        var viewModel = new TransactionViewModel(loans, monthlyTarget, salesAgent)
        
        return View(viewModel);
    }
