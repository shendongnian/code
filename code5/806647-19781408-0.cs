    // To save UserID in session
    Session.Add("userID", "123");
    // or
    Session["userID"] = "123";
    // Get UserID from session
    string userID = (string)(Session["userID"]);
    
    // Remove from session
    Session.Remove("userID");
