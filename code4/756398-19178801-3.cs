    /// <summary>
    /// Called from this project's App.xaml.cs file, or from the Deals Main Menu
    /// </summary>
    public class Bootstrapper
    {
        private SplashScreenViewModel _splashScreenVM;
        public Bootstrapper()
        {
            // Display SplashScreen
            _splashScreenVM = SplashScreenFactory.CreateSplashScreen(
                "MyCompany Deals", "Planning Grid", "Creating Repositories...", 200);
            // Overwrite GlobalInfo parameters and prepare an AuditLog to catch and log errors
            ApplicationFactory.AuditedDisplay(
                Assembly.GetExecutingAssembly().GetName(),
                () =>
                {
                    // Show overwritten version numbers from GlobalInfo on SplashScreen
                    _splashScreenVM.VersionString = string.Format("v{0}.{1}.{2}",
                        GlobalInfo.Version_Major, GlobalInfo.Version_Minor, GlobalInfo.Version_Build);
                    // Initiate ViewModel with new repositories
                    var viewModel = new PlanningGridViewModel(new MyCompany.Repositories.PlanningGridHeadersRepository(),
                        new MyCompany.Repositories.PlanningGridLinesRepository(),
                        _splashScreenVM);
                    // Initiate View with ViewModel as the DataContext
                    var view = new PlanningGridView(viewModel);
                    // Subscribe to View's Activated event
                    view.Activated += new EventHandler(Window_Activated);
                    // Display View
                    view.ShowDialog();
                });
        }
        /// <summary>
        /// Closes SplashScreen when the Window's Activated event is raised.
        /// </summary>
        /// <param name="sender">The Window that has activated.</param>
        /// <param name="e">Arguments for the Activated event.</param>
        private void Window_Activated(object sender, EventArgs e)
        {
            _splashScreenVM.ClosingView = true;
        }
