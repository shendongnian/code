    protected void dg_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
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
            e.Row.Cells[3].Text = totalDonations;
        }
    }
