        public bool CurrentUserIsInRole(string role)
        {
            return CurrentUserRoles.Contains(role);
        }
        
        private IEnumerable<string> currentUserRoles;
        public IEnumerable<string> CurrentUserRoles
        {
            get
            {
                if (currentUserRoles == null)
                {
                         var user = GetCurrentUser();
                    currentUserRoles = new List<string>
                    {
                        user.Role.Name
                    };
                }
                return currentUserRoles;
            }
        }
