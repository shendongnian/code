    else
    {
      string query = ".....";
      var ViewModel = db.Database.SqlQuery<HeadsViewModel>(query);
      return View(ViewModel.ToList().ToPagedList(1, 6));
    }
