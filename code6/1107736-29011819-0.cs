    private void button1_Click()
    {
    	if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(comboBox2.Text)
    	{ 
    	    MesageBox.Show(@"Please enter text into each box.");
            return;
    	}
        
        // if all textboxes have values then call update the database
    }
