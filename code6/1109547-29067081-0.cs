    private void textBox_Leave(object sender, System.EventArgs e)
    {
        _inMemoryDatabase.Add(((TextBox)sender).Text);
    }
	
	private void form2_Load(object sender, System.EventArgs e)
    {
	    foreach(var item in _inMemoryDatabase.GetData())
			listBox1.Items.Add(item);
    }
