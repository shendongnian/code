    public partial class ParentForm : Form
    {
        public ParentForm()
        {
            InitializeComponent();
        }
        private void sendAllButton_Click(object sender, EventArgs e)
        {
            SendConsoleGUI sendOutGUI = new SendConsoleGUI("Test");
            sendOutGUI.Show();     
        }
    }
    
    public partial class ChildForm : Form
    {
        public ChildForm(string str)
        {
            InitializeComponent();
            sendConsoleTextBox.Text = str;
        }
    }
