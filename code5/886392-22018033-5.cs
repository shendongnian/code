    public ActionResult Create(int? id)
    {
      var vm=new CreateJobVM();
      vm.ActionTypes=GetActionTypesFromSomewhere();
      vm.Incidents=GetIncidentsFromSomewhere();
      if(id.HasValue)
      {
         //set the selected item here
         vm.IncidentID =id.Value;
      }
      return View(vm);
    }
