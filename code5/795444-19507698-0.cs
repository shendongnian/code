    protected void dgRecords_OnUpdate(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Update")
        {
            string strInsitePriceID = dgRecords.DataKeys[e.Item.ItemIndex].ToString();
            TextBox temp, temp2, temp3;
            temp = (TextBox)e.Item.Cells[1].Controls[0];
            temp2 = (TextBox)e.Item.Cells[2].Controls[0];
            temp3 = (TextBox)e.Item.Cells[3].Controls[0];
            int intServicePartFrm = Int32.Parse(temp.Text);
            int intServicePartTo = Int32.Parse(temp2.Text);
            int fltPercentBaseAmt = Int32.Parse(temp3.Text);
