    string query = "UPDATE Ware SET Price = (Price * 1.02) WHERE WareNr > 0 AND WareNr <= 20000 AND Price >= 200";
    using(SqlConnection conn = new SqlConnection("YourConnectionString"))
    {
        using(SqlCommand comm = new SqlCommand(query, conn))
        {
            conn.Open();
            comm.ExecuteNonQuery();
        }
    }
