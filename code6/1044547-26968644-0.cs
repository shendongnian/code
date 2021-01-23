    public ActionResult MyAction(Session s)
    {
      var param1 = session["VAR1"];
      var param2 = session["VAR2"];
    
      return new CustomActionsRunner().MyAction(param1, param2);
    }
