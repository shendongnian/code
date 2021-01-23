    // use meaningful control/variable names
    string Material1 
    {
        get { return textBox1.Text; }
        set { textBox1.Text = value; }
    }
    string Material2
    {
        get { return textBox2.Text; }
        set { textBox2.Text = value; }
    }
    private void button1_Click(object sender, EventArgs e)
    { 
        if (String.IsNullOrWhiteSpace(Material1)) // handles also multiple spaces
        {
            MessageBox.Show("Enter Material Name Please.");  
            // return; <-- perhaps?   
        }
        if (Material1 == Material2)
        {
            MessageBox.Show("Materials are equal.");
        }
        else
        {
            MessageBox.Show("Materials don't match.");
        }
    }
