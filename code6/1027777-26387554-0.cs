    public partial class Form1 : Form
    {
        private Boolean _testBool;
        public Boolean TestBool
        {
            get { return _testBool; }
            set { _testBool = value; }
        }
        public Form1()
        {
            InitializeComponent();
            checkBox1.DataBindings.Add(new Binding("Checked", this, "TestBool", true, DataSourceUpdateMode.OnPropertyChanged));
            checkBox1.DataBindings[0].BindingComplete += Form1_BindingComplete;
        }
        private void Form1_BindingComplete(Object sender, BindingCompleteEventArgs e)
        {
            Debug.WriteLine("BindingComplete:  " + TestBool.ToString());
        }
    }
