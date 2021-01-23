    using (var userBinding = new DirectoryEntry("LDAP://domain.forest.company.com"))
    {
        using (DirectorySearcher adSearch = new DirectorySearcher(userBinding))
        {
            adSearch.ReferralChasing = ReferralChasingOption.All;
            adSearch.Filter = "(&((&(objectCategory=Person)(objectClass=User)))(samaccountname=" + username + "*))";
            adSearch.PropertiesToLoad.Add("employeeID");
            adSearch.PropertiesToLoad.Add("givenname");
            adSearch.PropertiesToLoad.Add("samaccountname");
            var result = adSearch.FindOne();
               
            var employeeId = result.Properties["employeeID"][0].ToString();
        }
    }
