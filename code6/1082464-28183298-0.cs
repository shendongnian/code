    public void Button1_Click(object sender, EventArgs e)
    {
        if(textBox.Text.Length > 0)
             textBox.Text += "-";
        
        Button butt = (Button)sender;
            
        textBox.Text += butt.Text;
    }
