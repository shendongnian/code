    public partial class Form1 : Form
    {
        private bool _testBool;
        public bool TestBool
        {
            get { return _testBool; }
            set { _testBool = value; }
        }
    
        public Form1()
        {
            InitializeComponent();
    
            checkBox1.DataBindings.Add(new Binding("Checked", this, "TestBool"));
            Load += new EventHandler(Form1_Load);
        }
    
        void Form1_Load(object sender, EventArgs e)
        {
            checkBox1.CheckedChanged += new EventHandler(checkBox1_CheckedChanged);
        }
    
        void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Not needed anymore
            //checkBox1.BindingContext[this].EndCurrentEdit();
    
            Debug.WriteLine(TestBool.ToString());
        }
    }
