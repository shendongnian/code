    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try 
        {
            GridViewRow row = GridView1.SelectedRow; 
            AccountNumber.Text = (string)row.Cells[0].Text;
             ....
            if (DropDownListCurrency.Items.FindByValue(row.Cells[8].Text.ToString().Trim()) != null)
            {
                DropDownListCurrency.SelectedValue = row.Cells[8].Text.ToString().Trim();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex);
        }
    }
