    public partial class MainForm : Form
    {
        AnotherForm anotherForm; // Declare a global object for AnotherForm
        public MainForm()
        {
            InitializeComponent();
        }
        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anotherForm = new AnotherForm(); // when Menu Item is clicked instantiate the Form
            anotherForm.FormClosing += new FormClosingEventHandler(anotherForm_FormClosing); // Add a FormClosing event Handler
            anotherForm.ShowDialog();
        }
        void anotherForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            inputTextBox.Text = anotherForm.listViewValue; // get the Value from public property in AnotherForm
        }
    }
