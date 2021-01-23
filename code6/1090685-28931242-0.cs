            #region Assign Direct Permission
            try
            {
                User user =
                        (User)activeDirectoryClient.Users.ExecuteAsync().Result.CurrentPage.ToList().FirstOrDefault();
                if (appObject.ObjectId != null && user != null && newServicePrincpal.ObjectId != null)
                {
                    AppRoleAssignment appRoleAssignment = new AppRoleAssignment();
                    appRoleAssignment.Id = appRole.Id;
                    appRoleAssignment.ResourceId = Guid.Parse(newServicePrincpal.ObjectId);
                    appRoleAssignment.PrincipalType = "User";
                    appRoleAssignment.PrincipalId = Guid.Parse(user.ObjectId);
                    user.AppRoleAssignments.Add(appRoleAssignment);
                    user.UpdateAsync().Wait();
                    Console.WriteLine("User {0} is successfully assigned direct permission.", retrievedUser.DisplayName);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Direct Permission Assignment failed: {0} {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }
