    using PagedList;
       
    public ActionResult Index(int? page)
    {
          var viewModel = new ViewModel();
          List users = GetLatestUsers();
          viewModel.Users = users;
                     
          int pageSize = 3;
          int pageNumber = (page ?? 1);
          return View(viewModel.Users.ToPagedList(pageNumber, pageSize));
    }
