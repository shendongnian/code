    private void button1_Click(object sender, EventArgs e)
    {
        int value;
        if (!Int32.TryParse(inMatningTextBox.Text, out value))
        {
           // show error message, because text is not integer
           return;
        } 
       
        if (value == Log.AnsNr)
        {
           // do your stuff
        }
    }
