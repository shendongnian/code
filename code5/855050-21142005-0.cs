    public ActionResult EditNonMember(int id, string feedback, string courseDateID, 
                                                                     string courseID)
    {
        //code to retrieve data here
        var userDetails=repositary.GetUserFromSomeId(id);
        vm.Employers=GetEmployers();
        vm.Employer = userDetails.Employer;
        vm.DirectorateList=GetDirectorateListForEmployer(userDetails.Employer);
        vm.DirectorateID = userDetails.DirectorateID;
    
        return View(vm);
    }
    private List<SelectListItem> GetEmployers()
    {
      // to do : Return all employers here in List<SelectListItem>
    }
    private List<SelectListItem> GetDirectorateListForEmployer(int employerId)
    {
      // to do : Return all Directorates for the selected employer 
    }
