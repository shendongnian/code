    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            trayMap.MyCustomClickEvent += MyCustomClickEvent;  // i'm assuming trayMap is the name of user control in main form.
        }
        private void btnInForm_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test Button In Form", "btnInForm Button Clicked", MessageBoxButtons.OK);
        }
        private void MyCustomClickEvent(object sender, EventArgs e)
        {
            Button button = sender as Button;
            MessageBox.Show("Test Button In TrayMap", button.Text + " Button Clicked", MessageBoxButtons.OK);
        }
    }
