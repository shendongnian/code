    private void button1_Click(object sender, EventArgs e)
    {
        using(Form2 f2 = new Form2())
        {
            // Pass the current text 
            f2.FileSelected = textBox1.Text;
            if(DialogResult.OK == f2.ShowDialog())
            {
                // read back the changes....
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
        // The property used to exchange the text between the two forms
        public string FileSelected {get;set;}
        private void Form_Load(object sender, EventArgs e)
        {
            // Let the user edit an initial value
            textBoxOnForm2.Text = this.FileSelected;
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            // Save the edited text to the property
            this.FileSelected = textBoxOnForm2.Text;
        }
    }
