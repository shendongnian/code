    public partial class MainPage : PhoneApplicationPage
    {
        private List<EventHandler<CancelEventArgs>> listOfHandlers = new List<EventHandler<CancelEventArgs>>();
        private void InvokingMethod(object sender, CancelEventArgs e)
        {
            for (int i = 0; i < listOfHandlers.Count; i++) 
                listOfHandlers[i](sender, e);
        }
        public event EventHandler<CancelEventArgs> myBackKeyEvent
        {
            add { listOfHandlers.Add(value); }
            remove { listOfHandlers.Remove(value); }
        }
        public void AddToTop(EventHandler<CancelEventArgs> eventToAdd)
        {
            listOfHandlers.Insert(0, eventToAdd);
        }
        public MainPage()
        {
            InitializeComponent();
            this.BackKeyPress += InvokingMethod;
            myBackKeyEvent += (s, e) => { MessageBox.Show("Added first"); e.Cancel = true; };
            AddToTop((s, e) => { MessageBox.Show("Added later"); });
        }
    }
