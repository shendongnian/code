    protected void textBox1_TextChanged(object sender, System.EventArgs e)
    {
        listBox1.Items.Clear();
        if (textBox1.Text.Length == 0)
        {
    		listBox1.Visible = false;
    		return;
        }
    
        foreach (String s in textBox1.AutoCompleteCustomSource)
        {
    		if (s.Contains(textBox1.Text))
    		{
    			listBox1.Items.Add(s);
    			listBox1.Visible = true;
    		}
        }
    }
    
    protected void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        textBox1.Text = listBox1.Items[listBox1.SelectedIndex].ToString();
        listBox1.Visible = false;
    }
