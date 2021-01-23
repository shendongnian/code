    private void txtDateFrom_TextChanged(object sender, EventArgs e)
    {
        DateTime dateValue;
        if(DateTime.TryParse(txtDateFrom.Text, System.Globalization.CultureInfo.InvariantCulture, dateValue))
        {
            TextBox2.Text = Convert.ToString(dateValue.AddDays(7));
        }
        else
        {
            TextBox2.Text = "Invalid DateTime inserted in txtDateFrom;";
        }
    }
