       public long RoleId
        {
            get
            {
                var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
                string id = identity.Claims.Where(c => c.Type == "http://myschema.com/app/claims/roleid")
                    .Select(c => c.Value).SingleOrDefault();
    
                //return 0 if no claim is located
                return (!String.IsNullOrEmpty(id)) ? Convert.ToInt32(id) : 0;
            }
            set
            {
                _userId = value;
            }
        }
