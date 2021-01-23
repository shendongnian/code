    public ActionResult CreatePost()
    {
      var vm=new CreatePostVM();
      //Adding 1 to 10 as per the question
      for(int i=0;i<10;i++)
      {
         vm.Pages.Add(new SelectListItem { Value=i.ToString(), Text=i.ToString()});
      }
      return View(vm);
    }
