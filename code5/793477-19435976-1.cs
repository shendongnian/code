    [HttpPost]
    public ActionResult CreateUser( UserViewModel model )
    {
       using ( PASSEntities context = new PASSEntities() )
       {
          AccountService service = new AccountService( context );
          service.CreateUser( model.Username, model.Password );
     
          // return something appropriate here     
       }
    }
