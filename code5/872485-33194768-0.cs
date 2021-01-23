    public string UserIdentity
            {
                get
                {
                    var user = UserManager.FindByName(User.Identity.Name);
                    return user;//user.Email
                }
            }
