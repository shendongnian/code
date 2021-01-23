    public ActionResult New(string type)
    {
        if (!string.IsNullOrWhiteSpace(type) && User.IsInRole("YOUR-ROLE-HERE"))
        {
            // Display NewCarType2 view if type requested and user is in correct role
            return View("NewCarType2");
        }
    
        // Default to New view if no type requested or user not in role
        return View("New");
    }
