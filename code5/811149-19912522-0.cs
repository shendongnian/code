    if ((String.IsNullOrEmpty(textBox1.Text.ToString().Trim())) && (radioButton1.Checked  || radioButton2.Checked))
    {
        button1.Enabled = true;
    }
    else
    {
        button1.Enabled = false;
    }
