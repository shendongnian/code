        public class Test
        {
            public void SignIn() {
                var authentication = HttpContext.GetOwinContext().Authentication;
                UserService.SignInUser(username, () => authentication.SignIn(), () => authentication.SignOut());
              }
        }
        public class UserService
        {
            public void SignInUser(Action onSigningIn, Func<int> onSigningOut)
            {
                // I don't check here if onSigningIn is null or not... that's all upon you
                onSigningIn();
                int n = onSigningOut();
            }
        }
