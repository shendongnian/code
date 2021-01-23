    [HttpPost]
    public ActionResult EditProfile(User m)
    {
        // Unrelated stuff
        var friends = m.FriendsText.Split(';').Select(c => {
            var args = c.Split('=');
            return new Friend { Name = args[0], Age = int.Parse(args[1]) };
        })
        // Use the collection
        // Unrelated stuff
    }
