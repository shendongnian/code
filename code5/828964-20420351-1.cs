        decimal totalAmt = 0.00M;
        for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
        {
            .
            .
            .
            .
            .
            ///////// -----> end of the for loop
            totalAmt = totalAmt + Convert.ToDecimal(Convert.ToString(box24.Text));
            totalAmt = totalAmt + Convert.ToDecimal(Convert.ToString(box25.Text));            
            totalAmt = totalAmt + Convert.ToDecimal(Convert.ToString(box26.Text));
        }
        TextBox box30 = (TextBox)GridView1.FooterRow.FindControl("Total Textbox ID");
        box30.Text = Convert.ToString(totalAmt);
