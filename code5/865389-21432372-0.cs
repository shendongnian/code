    public ActionResult Index()
        {
            MyViewModel model = new MyViewModel();
            
            model.List = GetAllData(User.IDentity.Name);;
    
            return View(model);
        }
    
    
        public JsonResult GetData(int i)
        {
            var model = GetAllData(User.IDentity.Name).Where(x => x.Data == i).ToList();
            return Json(model);
        }
