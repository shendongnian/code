    public ActionResult Index()
    {
        var vm = new MovieStudentVM();
        vm.Movies = db.Movies;
        vm.Students = db.Students;
        return View(vm);
    }
