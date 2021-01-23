    using System;
    using System.Collections.Generic;
    using System.DirectoryServices;
    using System.DirectoryServices.AccountManagement;
    
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                DirectoryEntry ldap;
                DirectorySearcher ldap_search;
                SearchResultCollection ldap_results;
                PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
    
                var addressLists = new Dictionary<string, string>();
    
    
                // Flexible way (but visually complex!) for building the path LDAP://CN=All Address Lists,CN=Address Lists Container,CN=First Organization,CN=Microsoft Exchange,CN=Services,CN=Configuration,DC=DOMAIN,DC=local
                ldap = new DirectoryEntry("LDAP://RootDSE");
                ldap_search = new DirectorySearcher(new DirectoryEntry("LDAP://CN=Microsoft Exchange, CN=Services," + ldap.Properties["configurationNamingContext"].Value), "(objectClass=msExchOrganizationContainer)");
                ldap_search = new DirectorySearcher(new DirectoryEntry("LDAP://CN=All Address Lists,CN=Address Lists Container," + ldap_search.FindOne().Properties["distinguishedName"][0]), "(objectClass=addressBookContainer)");
                ldap_search.Sort = new SortOption("name", SortDirection.Ascending);
    
                // Find All Address Lists alphabetically and put these into a dictionary
                ldap_results = ldap_search.FindAll();
                foreach (SearchResult ldap_result in ldap_results)
                {
                    var addressList = new DirectoryEntry(ldap_result.Path);
                    addressLists.Add(addressList.Properties["name"].Value.ToString(), addressList.Properties["distinguishedName"][0].ToString());
                }
    
                //// list Address Lists
                //foreach (var addressList in addressLists) Console.WriteLine(addressList.Key);
    
                // List all users from Address List "Aswebo"
                ldap = new DirectoryEntry("LDAP://" + ldap.Properties["defaultNamingContext"].Value); // rename ldap to LDAP://DC=DOMAIN,DC=local
                ldap_search = new DirectorySearcher(ldap, string.Format("(&(objectClass=User)(showInAddressBook={0}))", addressLists["Aswebo"])); // Search all users mentioned within the specified address list
                ldap_results = ldap_search.FindAll();
                foreach (SearchResult ldap_result in ldap_results)
                {
                    // Fetch user properties using the newer interface.. just coz it's nice :-)
                    var User = UserPrincipal.FindByIdentity(ctx, IdentityType.DistinguishedName, ldap_result.Path.Replace("LDAP://", ""));
                    Console.WriteLine(User.DisplayName);
                }
                
                Console.ReadLine();
            }
        }
    }
