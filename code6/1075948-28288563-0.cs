    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace LDAPCSharp
    {
    
        using System.DirectoryServices;
        using System.DirectoryServices.ActiveDirectory;
    
        class Program
        {
            static void Main(string[] args)
            {
                var ldapDomain = FriendlyDomainToLdapDomain("domainRemoved");
                
    
                var allResults = FindAllWithEmployeeNumber(ldapDomain);
    
                foreach (var searchResult in allResults)
                {
                    using (var entry = searchResult.GetDirectoryEntry())
                    {
                        foreach (var value in entry.Properties.PropertyNames)
                        {
                            Console.WriteLine(value);
                        }
                    }
                }
            }
    
            /// <summary>
            /// The find all.
            /// </summary>
            /// <param name="ldapDomain">
            /// The ldap domain.
            /// </param>
            /// <returns>
            /// The <see cref="IEnumerable"/>.
            /// </returns>
            public static IEnumerable<SearchResult> FindAllWithEmployeeNumber(string ldapDomain)
            {
                string connectionPrefix = "LDAP://" + ldapDomain;
                DirectoryEntry entry = new DirectoryEntry(connectionPrefix);
                DirectorySearcher mySearcher = new DirectorySearcher(entry);
                
                // all that have employeenumber set
                mySearcher.Filter = "(&(objectCategory=Person)(objectClass=User)(employeeNumber=*))";
    
                // all WITHOUT employeenumber set
                // mySearcher.Filter = (&(objectCategory=Person)(objectClass=User)(!(employeeNumber=*)))";
                mySearcher.PageSize = 10;
    
                var results = SafeFindAll(mySearcher);
             
                mySearcher.Dispose();
                return results;
            }
    
            public static string FriendlyDomainToLdapDomain(string friendlyDomainName)
            {
                string ldapPath = null;
                try
                {
                    DirectoryContext objContext = new DirectoryContext(
                        DirectoryContextType.Domain, friendlyDomainName);
                    Domain objDomain = Domain.GetDomain(objContext);
                    ldapPath = objDomain.Name;
                }
                catch (DirectoryServicesCOMException e)
                {
                    ldapPath = e.Message.ToString();
                }
                return ldapPath;
            }
    
            private static IEnumerable<SearchResult> SafeFindAll(DirectorySearcher searcher)
            {
                using (var results = searcher.FindAll())
                {
                    foreach (var result in results)
                    {
                        yield return (SearchResult)result;
                    }
                } // SearchResultCollection will be disposed here
            }
        }
    }
