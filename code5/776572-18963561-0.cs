    if (rbpApprove.Checked == true)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("Update table set IsActive= 0 where ARGID=@ARGID", conn);
        cmd.ExecuteNonQuery();
        conn.Close();        
    }
    else if (rbpReject.Checked == true)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("Update table set IsActive= 1 where ARGID=@ARGID", conn);
        cmd.ExecuteNonQuery();
        conn.Close();
    }
