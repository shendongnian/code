    public void Insert_Schedule(string empid, string status) 
    {
        // clear the parameters
        Comm.Parameters.Clear();
        Comm.Parameters.AddWithValue("@empid", empid);
        Comm.Parameters.AddWithValue("@status", status);
        Comm.ExecuteNonQuery();
    }
