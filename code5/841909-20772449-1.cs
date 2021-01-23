    public ActionResult Users()
        {
          // Get user list
            IEnumerable<User> users = HelperFunctions.GetAllUsers();
        
            // Return your view and pass it to your list
            return View(users);
        }
