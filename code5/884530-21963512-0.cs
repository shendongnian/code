    [HttpPost]
    public ActionResult BugJqGridDataRequested()
    {
    	using (var db = new BugContext()) {
    		var bugs = db.Bugs.ToList();
    		return Json(new {
    			/// The number of pages which should be displayed in the paging controls at the bottom of the grid.
    			Total = 1,
    			/// The current page number which should be highlighted in the paging controls at the bottom of the grid.
    			Page = 1,
    			/// Anything serializable
    			/// UserData = null,
    			
    			//The number of all available bugs not just the number of the returned rows!
    			Records = bugs.Count,
    			Rows = bugs
    		});
    	}
    }
