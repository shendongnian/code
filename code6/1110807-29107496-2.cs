    public class DetailsWindowDisplayer : IDetailsWindowDisplayer
    {
        private readonly IDetailsWindowFactory windowFactory;
        private readonly IDetailsWindowViewModelFactory viewModelFactory;
        public DetailsWindowDisplayer(
            IDetailsWindowFactory windowFactory,
            IDetailsWindowViewModelFactory viewModelFactory)
        {
            this.windowFactory = windowFactory;
            this.viewModelFactory = viewModelFactory;
        }
        public void ShowDetails(IPersonViewModel personViewModel)
        {
            var windowViewModel = this.viewModelFactory.Create(personViewModel);
            var window = this.windowFactory.Create(windowViewModel);
            window.Show();
        }
    }
