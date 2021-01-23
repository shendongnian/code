      [HttpPost]
            public ActionResult BlogPost(int id, string username, string email, string message)
            {
    var repo = new BlogRepository();
        
                if (ModelState.IsValid) {
        
                // help....
        
                    return RedirectToAction("BlogPost");
                }
                return View();
            }
    
    
    
     
