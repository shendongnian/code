    public partial class Form2 : Form
    {
        public Form2(int number)
        {
            InitializeComponent();
            this.textBox1.Text = number.ToString();
        }
        private int number = 0;
        public int Number
        {
            get { return this.number; }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(this.textBox1.Text, out value))
            {
                this.number = value;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            { 
                MessageBox.Show(textBox1.Text, "Invalid Integer");
            }
        }
    }
