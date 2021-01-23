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
