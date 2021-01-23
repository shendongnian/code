	void TextBox1TextChanged(object sender, System.EventArgs e)
	{
		var isTextEmpty  = ((TextBox)sender).Text.Trim() == "";
	    textBox2.Enabled = !isTextEmpty;
	}
	void TextBox2TextChanged(object sender, System.EventArgs e)
	{
		var isTextEmpty  = ((TextBox)sender).Text.Trim() == "";
        textBox1.Enabled = isTextEmpty;
	    textBox3.Enabled = !isTextEmpty;
	}
	void TextBox3TextChanged(object sender, System.EventArgs e)
	{
		var isTextEmpty  = ((TextBox)sender).Text.Trim() == "";
        textBox2.Enabled = isTextEmpty;
	    textBox4.Enabled = !isTextEmpty;
	}
	void TextBox4TextChanged(object sender, System.EventArgs e)
	{
		var isTextEmpty  = ((TextBox)sender).Text.Trim() == "";
        textBox3.Enabled = isTextEmpty;
	}
