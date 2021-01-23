    private void txtbxRecurEveryXWeeks_KeyPress(object sender, KeyPressEventArgs e)
    {
       if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
       {
           e.Handled = true;
       }
       if(txtbxRecurEveryXWeeks.Text == "0")
       {
           //Do something like clear the textbox value
       }
    }
