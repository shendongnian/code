    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Authenticator at = new Authenticator();
            if (at.validate(textBox1.Text)) {
                ListBox.Items.Add("Valid");
            }
        }
    }
    public class Authenticator
    {
        private int num;
        public bool validate(string s)
        {
            if (s == num.ToString())
            {
                 return true;
            }
            return false;
        }
    }
