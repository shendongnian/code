    DatabaseContext.Passwords
                   .Include("Creator")
                   .Where(pass => !pass.Deleted
                              && ((UserIDList.Contains(UserId))     // Why Check #1
                                   || (
                                       userIsAdmin                // Why Check #2
                                       &&                        // Why Check #3
                                       ApplicationSettings.Default.AdminsHaveAccessToAllPasswords
                                      )
                                  || pass.Creator_Id == UserId) 
                                 )
                   .Include(p => p.Parent_UserPasswords.Select(up => up.UserPasswordUser))
                   .SingleOrDefault(p => p.PasswordId == newPasswordId);
