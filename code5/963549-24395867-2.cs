        [PrincipalPermission(SecurityAction.Demand, Authenticated=true, Unrestricted=true)]
        public string GetData(string data)
        {
            string primaryIdentity;
            if (ServiceSecurityContext.Current != null)
                primaryIdentity = ServiceSecurityContext.Current.PrimaryIdentity.Name;
            else
                primaryIdentity = "Not found";
            int cookies = 0;
            var request = HttpContext.Current.Request;
            if (request != null && request.Cookies.Count > 0)
                cookies = request.Cookies.Count;
            return string.Format("You passed in: {0} - Primary Identity of Authenticated User: {1} - Found {2} cookies", data, primaryIdentity, cookies);
        }
