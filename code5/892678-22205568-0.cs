    public class MainPageViewModel
    {
        public MainPageModel Model { get; private set; }
    
        private void LoadAll()
        {
            _page = new MainPageModel();
            _page.PageTitle = "title";
        }
    }
