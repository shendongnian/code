    private void button1_Click(object sender, EventArgs e)
    {
        int Counter = 0;
    
        foreach (Control control in groupBox1.Controls)
        {
            TextBox textBox = control as TextBox;
    
            if (textBox != null)
                textBox.Text = Counter++.ToString();   
        }
    }
