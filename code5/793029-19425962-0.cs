    int total = 0;
    foreach (GridViewRow row in GridView1.Rows)
    {
        CheckBox chkselect = (CheckBox)row.FindControl("CheckBox1");
        Label lblcost = (Label)row.FindControl("Label5");
        if (chkselect.Checked)
        {         
            total += double.Parse(lblcost.Text);
        }
    }
    textBoxCost.Text = total.ToString();
