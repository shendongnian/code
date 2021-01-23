    public class ApplicationBarCreator
    {
        #region Constructor
        /// <summary>
        /// Constructor for native page
        /// </summary>
        /// <param name="page">Current page</param>
        public ApplicationBarCreator(PhoneApplicationPage page)
        {
            page.ApplicationBar = new ApplicationBar();
            page.ApplicationBar.IsMenuEnabled = true;
            page.ApplicationBar.IsVisible = true;
            ApplicationBarMenuItem appBarButtonSettings = new ApplicationBarMenuItem(LocalizedResources.Resources.Get("menusettings"));
            appBarButtonSettings.Click += delegate(object sender, EventArgs e)
            {
                appBarButtonSettings_Click(sender, e, page);
            };
            ApplicationBarMenuItem appBarButtonUpdate = new ApplicationBarMenuItem(LocalizedResources.Resources.Get("commonrefresh"));
            appBarButtonUpdate.Click += delegate(object sender, EventArgs e)
            {
                appBarButtonUpdate_Click(sender, e, page);
            };
            ApplicationBarMenuItem appBarButtonAbout = new ApplicationBarMenuItem(LocalizedResources.Resources.Get("menuhelp"));
            appBarButtonAbout.Click += delegate(object sender, EventArgs e)
            {
                appBarButtonAbout_Click(sender, e, page);
            };
         
            page.ApplicationBar.MenuItems.Add(appBarButtonSettings);
            page.ApplicationBar.MenuItems.Add(appBarButtonUpdate);
            page.ApplicationBar.MenuItems.Add(appBarButtonAbout);
            }
    
            private void appBarButtonSettings_Click(object sender, EventArgs e, PhoneApplicationPage page)
            {
                  // doing something
            }
            // and two more down
