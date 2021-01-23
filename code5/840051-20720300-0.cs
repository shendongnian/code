    namespace Date
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label2.Text = DateTime.Now.ToString(" hh:mm:ss tt");
            label4.Text = DateTime.Now.ToString(" dd-MM-yyyy ");
        }
        private void about_btn_Click(object sender, EventArgs e)
        {
            Form3 secondForm = new Form3();
            secondForm.Show();
        }
    }
    }  
