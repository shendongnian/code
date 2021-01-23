    private static bool valSAM(string samAccountName, string ldapAddress, string serviceAccountUserName, string serviceAccountPassword)
        {
            string ldapPath = "LDAP://" + ldapAddress;
    
            DirectoryEntry directoryEntry = new DirectoryEntry(ldapPath, serviceAccountUserName, serviceAccountPassword);
    
            StringBuilder builder = new StringBuilder();
    
            bool accountValidation = true;
    
            //create instance fo the directory searcher
            DirectorySearcher desearch = new DirectorySearcher(directoryEntry);
    
            //set the search filter
            desearch.Filter = "(&(sAMAccountName=" + samAccountName + ")(objectcategory=user))";
    
            //find the first instance
            SearchResult results = desearch.FindOne();
    
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, ldapAddress))
            {
    
                //if users are present in database
                if (results != null)
                {
    
                    //Check if account is activated
                    bool isAccountActived = IsActive(results.GetDirectoryEntry());
    
                    //Check if account is expired or locked
                    bool isAccountLocked = IsAccountLockOrExpired(results.GetDirectoryEntry());
    
                    accountValidation = ((isAccountActived != true) || (isAccountLocked));
    
                    //account is invalid 
                    if (accountValidation)
                    {
                        builder.Append("User account " + samAccountName + " is invalid. ");
    
                        if ((isAccountActived != true) && (isAccountLocked))
                        {
                            builder.Append("Account is inactive and locked or expired.").Append('\n'); ;
                        } else if (isAccountActived != true)
                        {
                            builder.Append("Account is inactive.").Append('\n'); ;
                        }
                        else if (isAccountLocked)
                        {
                            builder.Append("Account is locked or has expired.").Append('\n'); ;
                        }
                        else
                        {
                            builder.Append("Unknown reason for status. Contact admin for help.").Append('\n'); ;
                        }
    
                        accountValidation = false;
    
                    }
    
                    //account is valid
                    if ((isAccountActived) && (isAccountLocked != true))
                    {
                        builder.Append("User account " + samAccountName + " is valid.").Append('\n');
    
                        accountValidation = true;
                    }
    
                }
                else Console.WriteLine("Nothing found.");
    
                Console.WriteLine(builder);
    
                Console.ReadLine();
    
            }//end of using
            return accountValidation;
        }
