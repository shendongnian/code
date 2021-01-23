    public Form2(string sTEXT)
    {
    InitializeComponent();
    textBox1.Text = sTEXT;
    }
    
    2.) Goto Form1 then Double click it. At the code type this.
    //At your command button in Form1
    private void button1_Click(object sender, EventArgs e)
    {
    Form2 sForm = new Form2(textBox1.Text);
    sForm.Show();
    }
 
 
 
