    if (string.IsNullOrEmpty(textBox1.Text))
    {
    	MessageBox.Show("pls enter name");
        textBox1.Focus();
    	return;
    }
    
    Regex emp1=new Regex("^[a-z-A-Z]+$");
    if (!emp1.IsMatch(textBox1.Text))
    {
    	MessageBox.Show("no. are not allowed ");
    	return;
    }
