    //We will create a user identity class.This class will implement IIdentity interface.
        
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Security.Principal;
    
    
    namespace TechBook.Presentation.LoginClasses
    {
        public class UserIdentity: IIdentity
        {
            private bool isAuthenticated;
            private string authenticationType;
            private string userID;
            private string firstName;
            private string lastName;
            private List roles;
                    
            public UserIdentity(string UserID, bool IsAuthenticated, string AuthenticationType)
            {
                userID = UserID;
                isAuthenticated = IsAuthenticated;
                authenticationType = AuthenticationType;
            }
    
    
            public bool IsAuthenticated
            {
                get { return isAuthenticated; }
            }
            public string AuthenticationType
            {
                get { return authenticationType; }
            }
    
    
            public string Name
            {
                get { return userID; }
            }
    
    
            public string FirstName
            {
                get { return firstName; }
                set { firstName = value; }
            }
    
    
            public string LastName
            {
                get { return lastName; }
                set { lastName = value; }
            }
    
    
            public List Roles
            {
                get { return roles; }
                set { roles = value; }
            }
        }
    }
      
    
    //We will create a custom principal class. The class will implement IPrincipal interface.   
    
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Security.Principal;
    
    
    namespace TechBook.Presentation.LoginClasses
    {
        public class UserPrincipal :IPrincipal
        {
            private UserIdentity _userIdentity;
    
    
            public UserPrincipal(UserIdentity userIdentity)
            {
                _userIdentity = userIdentity;
            }
    
    
            public System.Security.Principal.IIdentity Identity
            {
                get { return _userIdentity; }
            }
    
    
            public bool IsInRole(string role)
            {
                return _userIdentity.Roles.Contains(role);
            }
        }
    }
    
    /*We have created these classes as we know identity and role are must to implement authentication and authorization.  Application must be able to identify the user.
    
    Now we need to write code for user authentication. */
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    namespace TechBook.Presentation.LoginClasses
    {
        public class SecurityManager
        {
            public bool Authenticate(string userName, string password)
            {
                BusinessEngine.Users user = new BusinessEngine.Users();
    
                user.UserName = userName;
                user.Password = password;
    
                if (new Business.Controller.UserController().validateUser(user) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
    
            public UserPrincipal ConstructUserPrincipal(System.Security.Principal.IIdentity iidentity)
            {
                int userId = Convert.ToInt32(iidentity.Name);
    
                if (userId &gt; 0)
                {
                    BusinessEngine.Users user = new BusinessEngine.Users();
                    user = new Business.Controller.UserController().getUserById(userId);
    
                    UserIdentity uidentity = new UserIdentity(userId.ToString(), iidentity.IsAuthenticated, iidentity.AuthenticationType);
                    uidentity.FirstName = user.FirstName;
                    uidentity.LastName = user.LastName;
    
                    List role = new List();
                    if (user.UserType.ToString().ToUpper().Equals("A"))
                    {
                        role.Add("Admin");
                        uidentity.Roles = role;
                    }
    
                    UserPrincipal uprincipal = new UserPrincipal(uidentity);
    
                    return uprincipal;
                }
                else
                {
                    return null;
                }
            }
        }
    }
    
    /*We have kept the userId in Context.User.Identity.Name (see UserIdentity class). using this we can query the database and get the user information. 
    
    Login Code*/
    
    
    protected void btnLogin_Click(object sender, EventArgs e)
            {
                TechBook.Presentation.LoginClasses.SecurityManager obj = new                    TechBook.Presentation.LoginClasses.SecurityManager();
                if (obj.Authenticate(txtUserName.Text.Trim(), txtPassword.Text.Trim()))
                {
                    BusinessEngine.Users user = new BusinessEngine.Users();
                    user.UserName = txtUserName.Text.Trim();
                    user.Password = txtPassword.Text.Trim();
                    
                    user = new Business.Controller.UserController().getUser(user);
                    FormsAuthentication.RedirectFromLoginPage(user.UserId.ToString(), false);
                }
            }
    
    /*We need user and role information everytime a request is received and thus we need to bind the code with authentication module. 
    
    Global.asax code*/
    
    
    protected void Application_AuthenticateRequest(object sender, EventArgs e)
            {
                if (this.User != null)
                {
                    TechBook.Presentation.LoginClasses.SecurityManager obj = new TechBook.Presentation.LoginClasses.SecurityManager();
    
                    TechBook.Presentation.LoginClasses.UserPrincipal principal = obj.ConstructUserPrincipal(this.User.Identity);
    
                    this.Context.User = principal;
    
                }
            }
