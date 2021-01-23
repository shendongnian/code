    corrected code
 
    {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Customer", cs);
            MySqlCommand cmdtwo = new MySqlCommand("SELECT SUM(Donation) AS Total_Donation FROM Customer", cs);
            cs.Open();
            MySqlDataReader dgl = cmd.ExecuteReader();
            dg.DataSource = dgl;
            dg.ShowFooter = true;
            dg.DataBind();
            cs.Close();
            cs.Open();
            string totalDonations = Convert.ToString(cmdtwo.ExecuteScalar());
            cs.Close();
            dg.FooterRow.Cells[7].Text = "Total £";
            dg.FooterRow.Cells[8].Text = totalDonations;
    }
    
