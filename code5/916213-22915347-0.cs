    private Textbox SelectedTextBox;
    
    protected void Form_Load(object sender, EventArgs e)
    {
        TextBox1.GotFocus += TextBox_GotFocus;
        TextBox2.GotFocus += TextBox_GotFocus;
    }
    
    private void clearBtn_Click(object sender, EventArgs e)
    {
        if(this.SelectedTextBox == null) return;
        string s = this.SelectedTextBox.Text;
        if (s.Length > 0) this.SelectedTextBox.Text = s.Substring(0, s.Length - 1);
    }
    
    private void TextBox_GotFocus(object sender, EventArgs e)
    {
        this.SelectedTextBox = (Textbox)sender;
    }
