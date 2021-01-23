    [HttpPost]
    public ActionResult Interview(InterviewViewModel model)
    {
      if(ModelState.IsValid)
      {
        //check for model.SelectedIntervieweID value
        //to do  :Save and redirect
      } 
      //Reload the dropdown data again before returning to view
      vm.Interviewers=GetInterViewrsFromSomewhere();
      return View(vm);
    }
