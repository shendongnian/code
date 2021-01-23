    protected void dg_DataBound(object sender, EventArgs e)
    {
        MySqlCommand cmd = new MySqlCommand("SELECT SUM(Donation) AS Total_Donation FROM Customer", cs);
        cs.Open();
        string totalDonations = cmd.ExecuteScalar();
        cs.Close();
        dg.FooterRow.Cells[0].Text = totalDonations;
    }
