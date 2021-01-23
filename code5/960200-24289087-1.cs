    model.Users = from user in users
                    let membershipUser = Membership.GetUser(user.UserName)
                    where membershipUser != null
                    select new UserBriefModel
                    {
                        Username = user.UserName,
                        Fullname = user.FullName,
                        Email = membershipUser.Email,
                        Roles = user.UserName.GetRoles()
                    };
