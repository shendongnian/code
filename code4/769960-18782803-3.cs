    public partial class LoginPageFacebook : PhoneApplicationPage
    {
        private readonly string AppId = Constants.FacebookAppId;
        private const string ExtendedPermissions = "user_birthday,email,user_photos";
        private readonly FacebookClient _fb = new FacebookClient();
        private Dictionary<string, object> facebookData = new Dictionary<string, object>();
        UserIdentity userIdentity = App.Current.Resources["userIdentity"] as UserIdentity;
        public LoginPageFacebook()
        {
            InitializeComponent();
        }
        private void webBrowser1_Loaded(object sender, RoutedEventArgs e)
        {
            var loginUrl = GetFacebookLoginUrl(AppId, ExtendedPermissions);
            webBrowser1.Navigate(loginUrl);
        }
        private Uri GetFacebookLoginUrl(string appId, string extendedPermissions)
        {
            var parameters = new Dictionary<string, object>();
            parameters["client_id"] = appId;
            parameters["redirect_uri"] = "https://www.facebook.com/connect/login_success.html";
            parameters["response_type"] = "token";
            parameters["display"] = "touch";
            // add the 'scope' only if we have extendedPermissions.
            if (!string.IsNullOrEmpty(extendedPermissions))
            {
                // A comma-delimited list of permissions
                parameters["scope"] = extendedPermissions;
            }
            return _fb.GetLoginUrl(parameters);
        }
        private void webBrowser1_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (waitPanel.Visibility == Visibility.Visible)
            {
                waitPanel.Visibility = Visibility.Collapsed;
                webBrowser1.Visibility = Visibility.Visible;
            }
            FacebookOAuthResult oauthResult;
            if (!_fb.TryParseOAuthCallbackUrl(e.Uri, out oauthResult))
            {
                return;
            }
            if (oauthResult.IsSuccess)
            {
                var accessToken = oauthResult.AccessToken;
                FBLoginSucceded(accessToken);
            }
            else
            {
                // user cancelled
                MessageBox.Show(oauthResult.ErrorDescription);
            }
        }
        private void FBLoginSucceded(string accessToken)
        {
            
            var fb = new FacebookClient(accessToken);
            fb.GetCompleted += (o, e) =>
            {
                if (e.Error != null)
                {
                    Dispatcher.BeginInvoke(() => MessageBox.Show(e.Error.Message));
                    return;
                }
                var result = (IDictionary<string, object>)e.GetResultData();
                var id = (string)result["id"];
                userIdentity.FBAccessToken = accessToken;
                userIdentity.FBID = id;
                facebookData["Name"] = result["first_name"];
                facebookData["Surname"] = result["last_name"];
                facebookData["Email"] = result["email"];
                facebookData["Birthday"] = DateTime.Parse((string)result["birthday"]);
                facebookData["Country"] = result["locale"];
                Dispatcher.BeginInvoke(() =>
                    {
                        BitmapImage profilePicture = new BitmapImage(new Uri(string.Format("https://graph.facebook.com/{0}/picture?type={1}&access_token={2}", id, "square", accessToken)));
                        facebookData["ProfilePicture"] = profilePicture;
                        userIdentity.FBData = facebookData;
                        userIdentity.ProfilePicture = profilePicture;
                        ARLoginOrRegister();
                    });
            };
            fb.GetAsync("me");
        }
        private void ARLoginOrRegister()
        {
            WebService.ARServiceClient client = new WebService.ARServiceClient();
            client.GetUserCompleted += client_GetUserCompleted;
            client.GetUserAsync((string)facebookData["Email"]);
            client.CloseAsync();
        }
        void client_GetUserCompleted(object sender, WebService.GetUserCompletedEventArgs e)
        {
            if (e.Result == null)
                NavigationService.Navigate(new Uri("/RegisterPageFacebook.xaml", UriKind.RelativeOrAbsolute));
            else if (e.Result.AccountType != (int)AccountType.Facebook)
            {
                MessageBox.Show("This account is not registered with facebook!");
                NavigationService.Navigate(new Uri("/LoginPage.xaml", UriKind.RelativeOrAbsolute));
            }
            else
            {
                userIdentity.Authenticated += userIdentity_Authenticated;
                userIdentity.FetchARSocialData((string)facebookData["Email"]);
            }
        }
        void userIdentity_Authenticated(bool success)
        {
            NavigationService.Navigate(new Uri("/MenuPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
