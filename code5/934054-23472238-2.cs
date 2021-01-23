    public partial class ChildForm : Form
    {
        public ChildForm()
        {
            InitializeComponent();
            MainForm.OnChildTextChanged += MainForm_OnChildTextChanged;
            MainForm.OnButtonClick += MainForm_OnButtonClick;
        }
        void MainForm_OnButtonClick(object sender, EventArgs e)
        {
            this.button1.PerformClick();
        }
        void MainForm_OnChildTextChanged(string value)
        {
            this.textBox1.Text = value;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("i am child");
        }
    }
