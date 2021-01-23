    // use meaningful control/variable names
    private string Material1 {
        get { return textBox1.Text; }
        set { textBox1.Text = value; }
    }
    private string Material2
    {
        get { return textBox2.Text; }
        set { textBox2.Text = value; }
    }
    private void button1_Click(object sender, EventArgs e)
    { 
        if (String.IsNullOrEmpty(Material1))
        {
            MessageBox.Show("Enter Material Name Please.");     
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
