        public class WPFViewModelPage
        {
            public SimpleViewModel SimpleViewModel { get; set; }
            public AsyncServerStud MockServer { get; set; }
    
            public WPFViewModelPage()
            {
                this.SimpleViewModel = new SimpleViewModel();
                this.MockServer = new AsyncServerStud();
            }
        }
