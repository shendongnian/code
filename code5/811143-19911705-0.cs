	if (!string.IsNullOrEmpty(textBox1.Text) && (radioButton1.Checked == true || radioButton2.Checked == true))
	{
		button1.Enabled = true;
	}
	else
	{
		button1.Enabled = false;
	}
