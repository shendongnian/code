    IIdentity id = WindowsIdentity.GetCurrent();
                WindowsIdentity winId = id as WindowsIdentity;
    
                if (id == null)
                {
                    CurrentUserEmail = "identity is not a windows identity";
                    return;
                }
            
                var name = winId.Name;
            
                string userInQuestion = name.Split('\\')[1];
                string myDomain = name.Split('\\')[0]; // this is the domain that the user is in
                // the account that this program runs in should be authenticated in there                    
    
                using (HostingEnvironment.Impersonate())
                {
                    DirectoryEntry entry = new DirectoryEntry("LDAP://" + myDomain);
                    DirectorySearcher adSearcher = new DirectorySearcher(entry);
    
                    adSearcher.SearchScope = SearchScope.Subtree;
                    adSearcher.Filter = "(&(objectClass=user)(samaccountname=" + userInQuestion + "))";
                    SearchResult userObject = adSearcher.FindOne();
                    if (userObject != null)
                    {
                        string[] props = new string[] {"mail"};
                        foreach (string prop in props)
                        {   //when it works set variable to CurrentUserEmail instead of txtDetailPrblem textbox
                            CurrentUserEmail = userObject.Properties[prop][0].ToString();
                        }
                    }
    
                }
