    public ActionResult Create(int? id)
    {
      var model=new Job();
      if(id.HasValue)
      {
        model.IncidentID=id.Value;
      }
      //to do :return something
    }
