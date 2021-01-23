    [Activity(Label = "", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class LoginActivity : AndroidActivity, ILoginManager
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Xamarin.Forms.Forms.Init(this, bundle);
            SetPage(App.GetLoginPage(this));
        }
        public void GetMainMenu()
        {
            StartActivity(new Intent(this, typeof(MainMenuActivity)));
            Finish();
        }
