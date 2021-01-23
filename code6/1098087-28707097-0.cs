    Int32 iAge;
    private void txtAge_TextChanged(Object sender, EventArgs e)
    {
        //Saves age in years...
        if (!Int32.TryParse(txtAge.Text, out iAge))
        {
            MessageBox.Show(String.Format("Conversion of '{0}' to Int32 failed!", txtAge.Text), "Bad Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        else
        {
            //it parsed into the Int32, so do something with it...
        }
    }
