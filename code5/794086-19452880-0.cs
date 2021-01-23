    public ActionResult Index()
    {
    
      somecodethatrunsforeverybody(); 
      if (Request.IsAuthenticated)
      {
        codethatrunsforauthenticatedusers();
      }
    
    }
