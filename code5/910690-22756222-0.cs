    public partial class MyControl : UserControl
    {
        private string myValue = "Default";
        public string MyValue
        {
            get { return myValue; }
            set
            {
                myValue = value;
                // alternatively you can add some code here which 
                // will be invoked after control is created
            }
        }
        public MyControl()
        {
            InitializeComponent();
        }
    }
