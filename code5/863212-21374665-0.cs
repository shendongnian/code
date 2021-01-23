    bool error = false;
    try
    {		
    	textbox3.Text = (Convert.ToInt64(textbox3.Text)).ToString();
    }
    catch
    { error = true; }
    
    if ((textbox3.Text).Length == 10)
    {
    	textbox4.Text = textbox1.Text + Environment.NewLine + textbox2.Text + Environment.NewLine + textbox3.Text; 
    }
    else
    	error = true;
    	
    if (error)
    {
    	textbox3.Text = string.Empty;
    	textbox4.Text = string.Empty;
    	MessageBox.Show("Please, enter a 10 digit Contact No.", "Error");
    }
