    partial void CustomersByLoggedInUser_PreprocessQuery(ref IQueryable<Customer> query)
        {
        if (!Application.Current.User.HasPermission(Permissions.SecurityAdministration))
        {
            Guid guid = (Guid)Membership.GetUser().ProviderUserKey;                
            IEnumerator cusUsers = this.CustomerUsers.GetEnumerator();
            CustomerUser current;
            CustomerUser found = null;
            while (cusUsers.MoveNext())
            {
                current = (CustomerUser)cusUsers.Current;
                if (current.GebruikerID == guid)
                {
                    found = current;
                }
            };
            try
            {                
                if (found != null)
                {
                    filter = e => e.CustomerID == found.Customer1.CustomerID;
                }
                else
                {
                    filter = e => e.CustomerID == "-1";
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
