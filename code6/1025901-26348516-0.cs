    private ConnectContext db = new ConnectContext();
    public ActionResult Index()
       {
          ViewModel vm = new ViewModel();
          vm.Model1 = (from m in db.Model1 select m).OrderByDescending(x => x.ID).Take(3).ToList();
          vm.Model2 = (from t in db.Model2 select t).OrderByDescending(x => x.ID).Take(3).ToList();
    
          return View(vm);
       }
