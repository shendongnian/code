    public class ADHelper
    {
            public static Employee getUserName(string loginName)
            {
                PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
                UserPrincipal principal = new UserPrincipal(ctx);
                principal.SamAccountName = Regex.Replace(loginName, ".*\\\\(.*)", "$1", RegexOptions.None);
    
                // create your principal searcher passing in the QBE principal    
                PrincipalSearcher srch = new PrincipalSearcher(principal);
    
                // find all matches
                Employee employee = new Employee();
                foreach (var found in srch.FindAll())
                {
                    UserPrincipal principal2 = (UserPrincipal)found;
                    //FirstName
                    employee.FirstName = principal2.GivenName;
                    //Middle Name
                    employee.MiddleName = principal2.MiddleName;
                    //LastName
                    employee.LastName = principal2.Surname;
                }
                return employee;
            }
        }
    
        public class Employee
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string MiddleName { get; set; }
            public string getFullName()
            {
                return LastName + ", " + FirstName + " " + MiddleName;
            }       
        }
    
