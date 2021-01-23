    private void txtDateFrom_TextChanged(object sender, EventArgs e)
    {
        DateTime dateValue;
        if(DateTime.Parse(txtDateFrom.Text, dateValue)
        {
            TextBox2.Text = Convert.ToString(dateValue.AddDays(7));
        }
        else
        {
            TextBox2.Text = "Invalid DateTime inserted in txtDateFrom;";
        }
    }
