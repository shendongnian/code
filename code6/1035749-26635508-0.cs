    private void radTextBoxNum_Validated(object sender, EventArgs e)
    {
        string newValue = radTextBoxNum.Text;
    
        while (newValue.Length < 15)
        {
            newValue = "0" + newValue;
        }
    
        radTextBoxNum.Text = newValue;
    }
