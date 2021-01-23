    [assembly: ExportRenderer (typeof (LoginPage), typeof (LoginPageRenderer))]
    
    namespace Demo.XForms.iOS
    {
        public class LoginPageRenderer : PageRenderer
        {
            public override void ViewDidAppear (bool animated)
            {
                base.ViewDidAppear (animated);
    
                var auth = new OAuth2Authenticator (
                    clientId: ...,
                    scope: "basic",
                    authorizeUrl: new Uri ("..."),
                    redirectUrl: new Uri ("..."));
    
                auth.Completed += (sender, eventArgs) => {
                    DismissViewController (true, null);
                    if (eventArgs.IsAuthenticated) {
                        App.SaveToken(eventArgs.Account.Properties["access_token"]);
                    } else {
                        // The user cancelled
                    }
                };
    
                PresentViewController (auth.GetUI (), true, null);
            }
        }
    }
