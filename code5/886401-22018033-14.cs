    public ActionResult Create(int? id)
    {
      var vm=new CreateJobVM();
      vm.ActionTypes=GetActionTypes();
      vm.Incidents=GetIncidents();
      if(id.HasValue)
      {
         //set the selected item here
         vm.IncidentID =id.Value;
      }
      return View(vm);
    }
