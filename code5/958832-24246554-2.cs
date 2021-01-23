    private void button1_Click(object sender, EventArgs e)
    {
        using(Form2 f2 = new Form2())
        {
            f2.FileSelected = textBox1.Text;
            if(DialogResult.OK == f2.ShowDialog())
            {
                textBox1.Text = f2.FileSelected;
            }
        }
    }
    //form2:
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string FileSelected {get;set;}
        
        private void cmdOK_Click(object sender, EventArgs e)
        {
            this.FileSelected = textBoxOnForm2.Text;
        }
    }
