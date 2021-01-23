    public ActionResult Index()
    {
      //ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
      ServiceReference1.Service1Client cs = new ServiceReference1.Service1Client();
      List<ServiceReference1.Story> tm  = cs.GetBollywoodStory();
    
      //populate viewmodel
      var movies = new  List<MovieViewModel>();
      foreach(var item in tm) {
         movies.Add(new MovieViewModel {
            Name = tm.Name;
            ...
         });
      }
      return View(movies);
    }
