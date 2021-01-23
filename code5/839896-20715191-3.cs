    var users = db.UserProfiles;
    var viewModel = new List<UserProfileIndexViewModel>();
    foreach (var user in users)
    {
        ProfileBase _userProfile = ProfileBase.Create(user.UserName);
        viewModel.Add(new UserProfileIndexViewModel {
            UserId = user.UserId,
            FirstName  = Convert.ToString(_userProfile.GetPropertyValue("FirstName")),
            LastName = Convert.ToString(_userProfile.GetPropertyValue("LastName")),
            Email = db.User_Contacts.Find(user.UserName).Contact.Email,
            ClientName = db.User_Clients.Find(user.UserName).Client.Name
        });
    }
    return View(viewModel);
