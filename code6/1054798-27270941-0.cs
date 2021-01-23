    using(SqlConnection con = new SqlConnection(@"Data Source=EPRAISE-PC;Initial Catalog=Cmanager;Integrated Security=True"))
    {
        ....
        ....
        using(SqlCommand sqlcmmd = con.CreateCommand())
        {
             sqlcmmd.CommandText = "Update Tithe SET Amount = @titheAmount, Date = @titheDate where MemberID = @MemberID AND Date = @titheDate";
             sqlcmmd.Parameters.Add("@MemberID").Value = titheMemID.Text;
             sqlcmmd.Parameters.Add("@titheAmount").Value = titheAmount.Text;
             sqlcmmd.Parameters.Add("@titheDate").Value = titheDateTime.Text;
             con.Open();
             sqlcmmd.ExecuteNonQuery();
        }
    }
