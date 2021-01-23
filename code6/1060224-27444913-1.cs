    public partial class MyTopScreen : Form
    {
        //keep your fields private.
        private bool _myVariable;
        private CommonForm _commonGridForm;
        //expose fields through properties.
        public bool MyVariable
        {
            get { return _myVariable; }
        }
        public CommonForm CommonGridForm
        {
            get { return _commonGridForm; }
        }
        public MyTopScreen(bool first_param, string second_param)
        {
            CommonForm commonGridForm = new CommonForm(this);
            DataGridView dataGridView1 = commonGridForm.dataGridView1;
            _commonAttributForm = commonAttributForm;          
            InitializeComponent();
            this.TabPage1.Controls.Add(dataGridView1);
        }
    }
    public partial class CommonForm : Form
    {
        private MyTopScreen _parent;
        //inject parent reference in child form's constructor.
        public CommonForm(MyTopScreen withParent)
        {
            _parent = withParent;
            //_parent.MyVariable <-- here's how you'd access your var.
        }
    }
