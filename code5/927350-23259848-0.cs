    [HttpPost]
    [FacebookAuthorize("email", "user_photos")]
        public async Task<ActionResult> Index(FormCollection form,FacebookContext context)
        {
            if (ModelState.IsValid)
            {
                string temp = form["txt"].ToString();
                var user = await context.Client.GetCurrentUserAsync<MyAppUser>();
    
    // my code , I use txt here
    
                return View(user);
            }
            return View("Error");
        }
