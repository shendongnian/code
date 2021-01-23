    public partial class ChildForm : Form
    {
        public ChildForm()
        {
            InitializeComponent();
        }
        internal String HellowWorld_mt(string SuffixValue)
        {
            return "hello world and "+ SuffixValue;
        }
    }
    public partial class ParentForm : Form
    {
        public ParentForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ChildForm cf = new ChildForm();
            cf.Show();
            string resp = cf.HellowWorld_mt(" extra!");
            this.Text = resp;
        }
    }
