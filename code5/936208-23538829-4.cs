    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
 
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
 
        [Display(Name = "Remember on this computer")]
        public bool RememberMe { get; set; }
        
        /// <summary>
        /// Checks if user with given password exists in LDAP
        /// </summary>
        /// <param name="_username">User name</param>
        /// <param name="_password">User password</param>
        /// <returns>True if user exist and password is correct</returns>
        public bool IsValid(string _username, string _password)
        {
            
            //Simple Active Directory Authentication Using LDAP and ASP.NET
	        var _path = "LDAP://a.b.c/dc=a,dc=b,dc=c";
            DirectoryEntry de = new DirectoryEntry(_path, _username, _password, AuthenticationTypes.Secure);
            try
            {
               //run a search using those credentials.
               //If it returns anything, then you're authenticated
               DirectorySearcher ds = new DirectorySearcher(de);
               SearchResult result = ds.FindOne();
               if (null == result)
               {
                  return false;
               }               
               return true;
            }
            catch (Exception ex)
            {
               //otherwise, it will crash out so return false
               return false;
            }
        }
    }
