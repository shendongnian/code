    public partial class Form1 : Form
    {
        private string vas;
        public Form1()
        {
            InitializeComponent();
        }
        public string Test { get;set; }
        private void button1_Click(object sender, EventArgs e)
        {
            Test = textBox1.Text;
            Form2 f2 = new Form2(this);
            f2.Show();
        }
    }
    public partial class Form2 : Form
    {
        private Form1 form1;
        public Form2(Form1 parentForm)
        {
            InitializeComponent();
            form1 = parentForm;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            //you can use the public string from Form1 here like this:
            textBox1.Text = form1.Test;
        }
    }
