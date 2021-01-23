    public partial class MainWindow : Window
    {
        private RelayCommand myRelayCommand ;
        private string param = "one";
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        public RelayCommand MyRelayCommand 
        {
            get
            {
                if (myRelayCommand == null)
                {
                    myRelayCommand = new RelayCommand((p) => { ServiceSelector(p); });
                }
                return myRelayCommand;
            }
        }
        private void DoSomething()
        {
            MessageBox.Show("Did Something");
        }
        
        private void ServiceSelector(object p)
        {
            DoSomething();
            
            if (param == "one")
                MessageBox.Show("one");
            else if (param == "two")
                MessageBox.Show("two");
            else
                MessageBox.Show("else");
            var name = param;
        }
    }
