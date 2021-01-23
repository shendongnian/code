	[AcceptVerbs("GET","POST")]
	public ActionResult Step8(int id = 0) {
		string _product = "";
		string _title = "";
	
		// was this a redirect back to us?
		try {
			if (TempData != null) {
				if (TempData.ContainsKey("product") && TempData["product"] != null) {
					_product = TempData["product"].ToString();
				}
				if (TempData.ContainsKey("title") && TempData["title"] != null) {
					_title = TempData["title"].ToString();
				}
			}
		} catch {}
		
		// The form in this view performs a POST to Step9
		return View(); 
	}
	[AcceptVerbs("POST")]
	public ActionResult Step9(int id = 0) {
		bool issue_found = true;
		if(issue_found){
			// hypothetical issue found, back to previous step
			TempData["title"] = "My Title";
			TempData["product"] = "My thing";
			return this.RedirectToAction("Step8");
		}else{
			// .. do stuff
			return View();
		}   
	}
