    public partial class NameList : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            new Form_TakingValue(listBox1).ShowDialog();
        }
    }
