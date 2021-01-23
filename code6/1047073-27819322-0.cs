    public partial class App : Application
    {
        
        private static IViewModelManager _ViewModelManager;
        public App()
            : base()
        {
            var dependencyResolver = this.GetDependencyResolver();
            _ViewModelManager = dependencyResolver.Resolve<IViewModelManager>();
            System.Windows.Input.CommandManager.RequerySuggested += RequerySuggested;
        }
        private void RequerySuggested(object sender, EventArgs e)
        {
            foreach (IViewModel viewModel in _ViewModelManager.ActiveViewModels)
            {
                (viewModel as ViewModelBase).GetViewModelCommandManager().InvalidateCommands(true);
            }
        }
    }
