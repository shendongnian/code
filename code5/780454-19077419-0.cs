    public bool radioButtons()
    {
        if (!userRadioButton.Checked && !adminRadioButton.Checked)
        {
            MessageBox.Show("You must select an account type");
            return false;
        }
        else
        {
            return true;
        }
    }
    public void button1_Click(object sender, EventArgs e)
    {
        
        if (radioButtons())
        {
           //Your code here
        }
    }
