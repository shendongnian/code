    protected void dg_DataBound(object sender, EventArgs e)
    {
        String totalDonations = string.Empty;
        //Assuming you have a connection string strConnect
        using (SqlConnection con = new SqlConnection(strConnect))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT SUM(Donation) AS Total_Donation FROM Custome", con))
            {
                totalDonations = Convert.ToString(cmd.ExecuteScalar());
            }
        }
       
        dg.FooterRow.Cells[3].Text = totalDonations;
    }
