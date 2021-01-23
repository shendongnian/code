    using System.Collections;
    using System.Collections.Generic;
    using System.DirectoryServices;
    using System.DirectoryServices.ActiveDirectory;
    using System.Linq;
    namespace AdTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var p = new Program();
                var users = p.GetMembersOf("LDAP://CN=SQL Adminsistrators,OU=_System accounts and groups,OU=Domain Users,DC=test,DC=net");
                // do something with users
            }
            private List<User> GetMembersOf(string groupdn)
            {
                var context = new DirectoryContext(DirectoryContextType.Forest);
                var Result = new List<User>();
                var GroupEntity = new DirectoryEntry(groupdn);
                var Members = (IEnumerable)GroupEntity.Invoke("Members", null);
                foreach (var member in Members)
                {
                    var UserEntry = new DirectoryEntry(member);
                    var User = GetUser(UserEntry);
                
                    if(User != null)
                        Result.Add(User);
                }
            
                return Result;
            }
            private User GetUser(DirectoryEntry UserEntry)
            {
                var Result = new User();
                foreach (PropertyValueCollection UserProperty in UserEntry.Properties)
                {
                    switch (UserProperty.PropertyName)
                    {
                        case "sAMAccountName":
                            Result.UserName = (string)UserProperty.Value;
                            break;
                        case "distinguishedName":
                            Result.DistinguishedName = (string)UserProperty.Value;
                            Result.DomainName = getDomainFromDN((string)UserProperty.Value);
                            break;
                        case "title":
                            Result.Title = (string)UserProperty.Value;
                            break;
                        case "department":
                            Result.Department = (string)UserProperty.Value;
                            break;
                        case "displayName":
                            Result.DisplayName = (string)UserProperty.Value;
                            break;
                        case "objectClass":
                            var UserClasses = (object[])UserProperty.Value;
                            if (UserClasses.Contains("user"))
                                break;
                            else
                                return null;
                        default:
                            break;
                    }
                }
                return Result;
            }
            private string getDomainFromDN(string p)
            {
                return string.Empty;
            }
            public string groupDN { get; set; }
        }
    }
