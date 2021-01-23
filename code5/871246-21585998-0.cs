    using (var GetName = new SqlCommand("SELECT Name FROM Ticket WHERE UserID = @UserID", conn))
    {
        GetName.Parameters.AddWithValue("@UserID", lblID.Text);
        using (SqlDataReader dr = GetName.ExecuteReader())
        {
            if (dr.Read())
            {
                lblGetData.Text = dr.GetString(dr.GetOrdinal("Name"));
            }
        }
    }
