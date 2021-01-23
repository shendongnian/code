    private static bool IsUserInRole(User user, AppRole appRole, bool roleAlreadyAssigned = false)
            {
            var userFetcher = user as IUserFetcher;
            IPagedCollection rawObjects = (IPagedCollection)userFetcher.AppRoleAssignments.ExecuteAsync().Result;
            foreach (IAppRoleAssignment item in rawObjects.CurrentPage)
                {
                if (item.Id == appRole.Id)
                    {
                    roleAlreadyAssigned = true; break;
                    }
                }
            return roleAlreadyAssigned;
            }
