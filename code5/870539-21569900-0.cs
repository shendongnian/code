    public partial class MyCustomUserControl : UserControl
    {
        public event EventHandler<EventArgs> MyCustomClickEvent;
        public MyCustomUserControl()
        {
            InitializeComponent();
        }
        public bool CheckBoxValue
        {
            get { return checkBox1.Checked;}
            set { checkBox1.Checked = value; }
        }
        public string SetCaption
        {
            get { return groupBox1.Text;}
            set { groupBox1.Text = value;}
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MyCustomClickEvent(this, e);
           
        }
    }
