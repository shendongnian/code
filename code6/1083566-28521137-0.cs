                IList<IAppRoleAssignment> assignments = rawObjects.CurrentPage.ToList();
                IAppRoleAssignment a = null;
                a = assignments.Where(ara => ara.Id.Equals(appRole.Id)).First();
                if (a != null)
                    Console.WriteLine("Found assignment {0} for user {1}", appRole.Id, user.DisplayName); 
