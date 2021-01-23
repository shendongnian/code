    public class LoginActivity : MvxAppCompatActivity<LoginViewModel>
    {   
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_login);
        }
        /// <summary>
        /// Removes activity from history after navigating to new activity.
        /// </summary>
        protected override void OnStop()
        {
            base.OnStop();
            Finish();
        }
        /// <summary>
        /// Closes app if back button is pressed.
        /// </summary>
        public override void OnBackPressed()
        {
            if (FragmentManager.BackStackEntryCount > 0)
            {
                FragmentManager.PopBackStack();
            }
            else
            {
                base.OnBackPressed();
            }
        }
    }
