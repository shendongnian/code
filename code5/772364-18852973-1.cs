    public ActionResult Interview()
    {
      var vm=new InterviewViewModel();
      vm.Interviewers =GetInterViewrsFromSomewhere();
      return View(vm);
    }
    public List<SelectListItem> GetInterViewrsFromSomewhere()
    {
      var list=new List<SelectListItem>();
      //Items hard coded for demo. you can read from your db and fill here
      list.Add(new SelectListItem { Value="1", Text="AA"});
      list.Add(new SelectListItem { Value="2", Text="BB"});
      return list;
    }
