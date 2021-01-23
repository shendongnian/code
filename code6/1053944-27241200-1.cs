    public void Insert_Schedule(string empid, string status) 
    {
        Comm.Parameters.AddWithValue("@empid", empid);
        Comm.Parameters.AddWithValue("@status", status);
        Comm.ExecuteNonQuery();
    }
