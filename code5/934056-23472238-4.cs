    public partial class ChildForm : Form
    {
        public ChildForm()
        {
            InitializeComponent();
            MainForm.OnChildTextChanged += MainForm_OnChildTextChanged;
            MainForm.OnButtonClick += MainForm_OnButtonClick;
            bttn1.Visible = false;
        }
        void MainForm_OnButtonClick(object sender, EventArgs e)
        {
            this.bttn1.PerformClick();
        }
        void MainForm_OnChildTextChanged(string value)
        {
            this.textBox1.Text = value;
        }
        private void bttn1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("I am hide. But shows message");
        }
    }
    public class Bttn : Button
    {
        public new void PerformClick()
        {
            this.OnClick(EventArgs.Empty);
        }
    }
