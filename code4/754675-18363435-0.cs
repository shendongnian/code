    [HttpGet]
    public ActionResult FollowUp(string contacted, string pid, int? id) 
    {
       if(!string.IsNullOrEmpty(contacted) && !string.IsNullOrEmpty(pid)) {
          // do your logic.
       }
       else if(!string.IsNullOrEmpty(contacted) && id != null) {
          // do your logic.
       }
    }
