    public interface IUserService {
            /// <summary>
            /// Register User to Identity Database
            /// </summary>
            /// <param name="userManager">User Manager to Handle Registration</param>
            /// <param name="user">User to add to database</param>
            /// <param name="password">User's password</param>
            /// <returns></returns>
            Task<IdentityResult> Register(UserManager<User, string> userManager, User user, string password);
            /// <summary>
            /// Login User
            /// </summary>
            /// <param name="signinManager">Signin Manager to handle login</param>
            /// <param name="email">Email of user</param>
            /// <param name="password">Password of user</param>
            /// <param name="rememberMe">Boolean if the user wants to be remembered</param>
            /// <returns></returns>
            Task<SignInStatus> Login(SignInManager<User, string> signinManager, string email, string password, bool rememberMe);
            /// <summary>
            /// Verify that code sent to User is valid
            /// </summary>
            /// <param name="signinManager">Signin Manager to handle verification</param>
            /// <param name="provider">Provider of the code</param>
            /// <param name="code">The code</param>
            /// <param name="rememberMe">Boolean if user wants to be remembered</param>
            /// <param name="rememberBrowser">Boolean if browser should be remembered</param>
            /// <returns></returns>
            Task<SignInStatus> VerifyCode(SignInManager<User, string> signinManager, string provider, string code, bool rememberMe, bool rememberBrowser);
            /// <summary>
            /// Confirm email of User
            /// </summary>
            /// <param name="userManager">User Manager to handle confirmation</param>
            /// <param name="userId">String user Id of the User</param>
            /// <param name="code">User code sent in Email</param>
            /// <returns></returns>
            Task<IdentityResult> ConfirmEmail(UserManager<User, string> userManager, string userId, string code);
            void ForgotPassword();
            void ForgotPasswordConfirmation();
            void ResetPassword();
            void ResetPasswordConfirmation();
            void ExternalLogin();
            void SendCode();
            void ExternalLoginCallback();
            void ExternalLoginConfirmation();
            /// <summary>
            /// Log off user from the Application
            /// </summary>
            /// <param name="AuthenticationManager">Application Manager to handle Sign out</param>
            void Logoff(IAuthenticationManager AuthenticationManager);
            /// <summary>
            /// Get user based on their Email
            /// </summary>
            /// <param name="Email">Email of user</param>
            /// <returns>User</returns>
            User GetUser(string Email);
            /// <summary>
            /// Get User by their GUID
            /// </summary>
            /// <param name="ID">GUID</param>
            /// <returns>User</returns>
            User GetUserById(string ID);
        }
