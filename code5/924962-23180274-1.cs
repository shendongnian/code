    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < Repeater1.Items.Count; i++)
        {
            Panel pnl_active = Repeater1.Items[i].FindControl("panel1") as Panel;
            Label Expected = Repeater1.Items[i].FindControl("Label1") as Label;
            DropDownList DDLValue = Repeater1.Items[i].FindControl("DropDownList3") as DropDownList;
            //You need to compare the SelectedItem.Text with the label Expected.Text
            if (DDLValue.SelectedItem.Text == Expected.Text)
            {
                pnl_active.Visible = true;
            }
        }
    }
