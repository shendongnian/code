    [Activity(Label = "", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize |   ConfigChanges.Orientation)]
    public class MainActivity : AndroidActivity, IAppNavigation
    {
        protected override void OnCreate(Bundle bundle)
        {
            //Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);
           
            Xamarin.Forms.Forms.Init(this, bundle);
            SetPage(App.GetShowSplashPage(this));
        }
       
        public void GetLoginPage()
        {
            StartActivity(new Intent(this, typeof(LoginActivity)));
            Finish();
        }
