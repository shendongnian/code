            var users = Sitecore.Security.Accounts.UserManager.GetUsers();
            foreach (Sitecore.Security.Accounts.User user in users)
            {
                var membershipUser = System.Web.Security.Membership.GetUser(user.Name, false);
                if (membershipUser != null)
                {
                    var date = membershipUser.CreationDate;
                }
            }
