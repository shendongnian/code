    private void MainForm_Load(object sender, EventArgs e)
    {
        //some code here
        if (condition == false)
        {
            MessageBox.Show("Condition not met. Program will now close!");
            //i log the user logged in
            this.Close();
        } 
        else 
        {
             //continue to setup the form
        }
    }
