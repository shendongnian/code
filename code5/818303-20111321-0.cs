    corrected code
    protected void Button2_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Customer", cs);
            cs.Open();
            MySqlDataReader dgl = cmd.ExecuteReader();
            dg.DataSource = dgl;
            dg.ShowFooter = true;
            dg.DataBind();
            cs.Close();
            
            MySqlCommand cmdtwo = new MySqlCommand("SELECT SUM(Donation) AS Total_Donation FROM Customer", cs);
            cs.Open();
            string totalDonations = Convert.ToString(cmdtwo.ExecuteScalar());
            cs.Close();
            dg.FooterRow.Cells[9].Text = totalDonations;
