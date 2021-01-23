    public ActionResult Manage(string friendId, FacebookContext context)
    {
        var friend = await context.Client.GetFacebookObjectAsync<MyAppUserFriend>(friendId);
        // var user = await context.Client.GetCurrentUserAsync<Models.MyAppUser>();
        if (MyDALFunction.GetUserByMail(friend.Email) == null) {
            // Create user functions, create a ViewModel, pass it on and do some editing.
        }
        return View(user);
    }
