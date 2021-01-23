    namespace ADTestApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                bool exit = false;
                do {
                    Console.WriteLine(".NET Version: " + (IsNet45OrNewer() ? "4.5" : "4"));
                    Console.WriteLine("enter search query");
                    string searchQuery = Console.ReadLine();
                    List<AdUser> adusers = Ldap1(searchQuery);
                    foreach (AdUser adUser in adusers)
                    {
                        Console.WriteLine(adUser.Mail + " : " + adUser.Surname + ", " + adUser.GivenName + " (" + adUser.MiddleName + ") : " + adUser.Phone + " : " + adUser.Description + " : " + adUser.Department);
                    }
                } 
                while(exit == false);
            }
            public static bool IsNet45OrNewer()
            {
                // Class "ReflectionContext" exists from .NET 4.5 onwards.
                return Type.GetType("System.Reflection.ReflectionContext", false) != null;
            }
            public static List<AdUser> Ldap1(string ldapSearch)
            {
                // configuration settings!!
                var ldapServer = "GC://mydomain.com";
                //anr = ambigous name resolution, will search for firstname, lastname, email and combination of it
                //userAccountControl:1.2.840.113556.1.4.803:=2 = only use enabled users
                string ldapFilter = (string.Format("(&(anr={0})(!userAccountControl:1.2.840.113556.1.4.803:=2))", ldapSearch));
                //string ldapAttributes = "cn,department,sn,givenName,surname,middlename,description,telephoneNumber,mail,distinguishedName,userPrincipalName,sAMAccountName,lastLogonTimestamp";
                PropertyInfo[] classProperties = typeof(AdUser).GetProperties(BindingFlags.Public);
                // return a list of users (might be an empty list)
                List<AdUser> dt = new List<AdUser>();
                // initiate searcher
                DirectoryEntry de = new DirectoryEntry(ldapServer);
                DirectorySearcher deSearch = new DirectorySearcher(de);
                try
                {
                    // adjust search attributes
                    deSearch.Filter = ldapFilter;
                    deSearch.SearchScope = SearchScope.Subtree;
                    deSearch.SizeLimit = 100;
                    deSearch.ServerTimeLimit = new TimeSpan(30);
                    // define attributes to be returned by a search
                    foreach (PropertyInfo s in classProperties)
                    {
                        deSearch.PropertiesToLoad.Add(s.Name.ToLower());
                    }
                    // do search
                    SearchResultCollection results = deSearch.FindAll();
                    // analyze data
                    foreach (SearchResult result in results)
                    {
                        var u = new AdUser();
                        var p = result.Properties;
                        if (p.PropertyNames != null)
                        {
                            foreach (string key in p.PropertyNames)
                            {
                                foreach (var values in p[key])
                                {
                                    switch (key.ToLower())
                                    {
                                        case "adspath": // always returned
                                            u.AdsPath = values.ToString();
                                            break;
                                        case "cn":
                                            u.CN = values.ToString();
                                            break;
                                        case "sn":
                                            u.Surname = values.ToString();
                                            u.SN = values.ToString();
                                            break;
                                        case "givenname":
                                            u.GivenName = values.ToString();
                                            break;
                                        case "surname":
                                            u.Surname = values.ToString();
                                            break;
                                        case "middlename":
                                            u.MiddleName = values.ToString();
                                            break;
                                        case "department":
                                            u.Department = values.ToString();
                                            break;
                                        case "description":
                                            u.Description = values.ToString();
                                            break;
                                        case "mail":
                                            u.Mail = values.ToString();
                                            break;
                                        case "distinguishedname":
                                            u.DistinguishedName = values.ToString();
                                            int idx = u.DistinguishedName.IndexOf("DC=");
                                            string x = u.DistinguishedName.Substring(idx + 3);
                                            idx = x.IndexOf(",");
                                            u.Domain = (idx > 0) ? x.Substring(0, idx) : x;
                                            break;
                                        case "telephonenumber":
                                            u.Phone = values.ToString();
                                            break;
                                        case "userprincipalname":
                                            u.UserPrincipalName = values.ToString();
                                            break;
                                        case "samaccountname":
                                            u.Account = values.ToString();
                                            break;
                                        default:
                                            // log entry??
                                            break;
                                    } // end switch
                                } // foreach values
                            } // foreach key
                        }
                        dt.Add(u);
                    }
                    de.Close();
                }
                catch (Exception ex) { throw ex; }
                finally
                {
                    deSearch.Dispose();
                    de.Dispose();
                }
                return dt;
            }
        }
        public class AdUser
        {
            public string AdsPath { get; set; }
            public string CN { get; set; }
            public string GivenName { get; set; }
            public string Surname { get; set; }
            public string MiddleName { get; set; }
            public string Description { get; set; }
            public string SN { get; set; }
            public string DN { get; set; }
            public string Mail { get; set; }
            public string Phone { get; set; }
            public string Department { get; set; }
            public string DistinguishedName { get; set; }
            public string UserPrincipalName { get; set; }
            public string Account { get; set; }
            public string Domain { get; set; }
        }
    }
