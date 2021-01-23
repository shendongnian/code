    // This variable tracks whether or not our code is changing the text
    // If it's set to false, then the user is changing the text
    private bool ignoreTextChange = false;
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        if (ignoreTextChange)
        {
            // Our code is changing the text, so just reset the variable
            ignoreTextChange = false;
        }
        else
        {
            // The user is changing the text, so set our 
            // variable and clear the other text box
            ignoreTextChange = true;
            this.textBox2.Text = "";   
        }        
    }
    private void textBox2_TextChanged(object sender, EventArgs e)
    {
        if (ignoreTextChange)
        {
            ignoreTextChange = false;
        }
        else
        {
            ignoreTextChange = true;
            this.textBox1.Text = "";
        }  
    }
