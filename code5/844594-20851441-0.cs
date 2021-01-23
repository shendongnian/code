    using (var con = new SqlConnection("Data Source=localhost;Initial Catalog=bkdb;User ID=sa;Password=sa"))
    using (var cmd = new SqlCommand(
        "UPDATE Registration SET [Attending] = 1 WHERE [Email] = @Email and [AttendingCode] LIKE @AttendingCode",
        con))
    {
        cmd.Parameters.AddWithValue("@Email", Email);
        cmd.Parameters.AddWithValue("@AttendingCode", string.Format("%{0}%", AttendingCode));
        con.Open();
        cmd.ExecuteNonQuery();
    }
