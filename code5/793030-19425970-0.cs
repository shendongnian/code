    decimal total = 0;
    decimal value = 0;
    foreach (GridViewRow row in GridView1.Rows)
    {
        CheckBox chkselect = (CheckBox)row.FindControl("CheckBox1");
        Label lblcost = (Label)row.FindControl("Label5");
        if (chkselect.Checked)
        {
            if (decimal.TryParse(lblcost.Text, out value))
            {
                total += sum;
            }
        }
    }
