    protected void chkChanged(object sender, EventArgs e)
    {
        GridViewRow row = (GridViewRow) (sender as CheckBox).Parent.Parent;
        CheckBox chk = (sender as CheckBox);
        TextBox comp = row.Cells[11].Controls[0] as TextBox;
        TextBox totalAmt = row.Cells[7].Controls[0] as TextBox;
        TextBox paid = row.Cells[8].Controls[0] as TextBox;
        TextBox datePaid = row.Cells[12].Controls[0] as TextBox;
        if (chk.ID.Equals("CB_Completed") && chk.Checked)
        {
            comp.Text = DateTime.Now.ToString();
        }
        else if (chk.ID.Equals("CB_Completed") && !chk.Checked)
        {
            comp.Text = "";
        }
        if (chk.ID.Equals("CB_PaidInFull") && chk.Checked)
        {
           datePaid.Text = DateTime.Now.ToString();
           paid.Text = totalAmt.Text;
        }
        else if (chk.ID.Equals("CB_PaidInFull") && !chk.Checked)
        {
            datePaid.Text = "";
            paid.Text = "";
        }
    }
