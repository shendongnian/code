    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (checkBox1.Checked) 
            listBox1.Items.Add(checkBox1.Text);
        else
            listBox1.Items.Remove(checkBox1.Text);
    }
    private void checkBox2_CheckedChanged(object sender, EventArgs e)
    {
        if (checkBox2.Checked) 
            listBox1.Items.Add(checkBox2.Text);
        else
            listBox1.Items.Remove(checkBox2.Text);
                
    }
    
    private void checkBox3_CheckedChanged(object sender, EventArgs e)
    {
        if (checkBox3.Checked) 
            listBox1.Items.Add(checkBox3.Text);
        else
            listBox1.Items.Remove(checkBox3.Text);
                
    }
    
    private void checkBox4_CheckedChanged(object sender, EventArgs e)
    {
       if (checkBox4.Checked) 
          listBox1.Items.Add(checkBox4.Text);
       else
          listBox1.Items.Remove(checkBox4.Text);
                
    }
                
