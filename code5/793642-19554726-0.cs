        private string GetADName(string userID)
        {
            try
            {
                using (HostingEnvironment.Impersonate())
                {
                    PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
               
                    UserPrincipal qbeUser = new UserPrincipal(ctx);
                    qbeUser.SamAccountName = userID.ToLower();
                    PrincipalSearcher srch = new PrincipalSearcher(qbeUser);
                    foreach (var found in srch.FindAll())
                    {
                        if (found.SamAccountName.ToLower() == userID.ToLower())
                        {
                            return found.Name;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return "";
        }
