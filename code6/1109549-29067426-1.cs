    public partial class Form_TakingValue : Form
    {
        ListBox listBox;
        public Form_TakingValue()
        {
            InitializeComponent();
        }
        public Form_TakingValue(ListBox lBox)  // -> Overloaded function for our needs
        {
            InitializeComponent();
            listBox = lBox;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            listBox.Items.Add(txtName.Text); // this listBox belongs to the first form and we are making changes to it from here..
            Close();
        }
    }
