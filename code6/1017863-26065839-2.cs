    private TextBox wc;
    Form()
    {
         InitializeComponent();
         wc = new TextBox();
         wc.TextChanged += wc_TextChanged;
         wc.Visible = false;
         Controls.Add(wc);
    }
    private void button1_Click(object sender, EventArgs e)
    {
         wc.Visible = true;
    }
    
