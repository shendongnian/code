    private void greenTextBox_TextChanged(object sender, EventArgs e)
    {
    	if (Convert.ToInt32(textBox2.Text.Trim()) <= 0)
    	{
    		redNumericUpDown.Visible = false;
    		redNumericUpDown.Refresh();
    	}
    	else
    	{
    		redNumericUpDown.Visible = true;
    		redNumericUpDown.Refresh();
    	}
    }  
    private void redNumericUpDown_ValueChanged(object sender, EventArgs e)
    {
    	blueTextBox.Text = redNumericUpDown.Value.ToString();
    	greenTextBox.Text = (10 - redNumericUpDown.Value).ToString();
    }
    
