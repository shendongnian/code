    public class MainVm
    {
        System.Threading.Timer timer;
        private string searchText = string.Empty;
        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                timer.Change(1000, System.Threading.Timeout.Infinite); //reset the timer
            }
        }
        public MainVm()
        {
            timer = new System.Threading.Timer(RefreshView, 
                                               null, 
                                               System.Threading.Timeout.Infinite,
                                               System.Threading.Timeout.Infinite);
        }
        private void RefreshView(object state)
        {
            //Here you need to use the dispatcher because the callback is called
            //from a non-UI thread
            Application.Current.Dispatcher.Invoke(()=>
                _functionProvidersView.Refresh()
            );
        }
    }
