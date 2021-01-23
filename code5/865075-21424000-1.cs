    public List<StudentInfo> GetData()
    {
        List<StudentInfo> data = new List<StudentInfo>();
        SqlConnection con = new SqlConnection("Your connection string");
        SqlCommand command = new SqlCommand("SELECT * FROM [Registration]", con);
        con.Open();
        SqlDataReader sdr = command.ExecuteReader();
        while(sdr.Read())
        {
             data.Add((int)sdr["ID"], (string)sdr["Name"], (string)sdr["Email"], (string)sdr["PhoneNo"]);
        }
        con.Close();
        return data;
    }
