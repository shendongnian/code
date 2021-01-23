    using (SqlConnection con = new SqlConnection("Server=ServerName;Database=byte;User=USR;Pwd=PSW;"))
    {
        con.Open();
        string INstring;
        INstring = "INSERT INTO BWDrfid(RFID,EmpNum) VALUES (@RFID, EID)";
        using (SqlCommand cmd = new SqlCommand(INstring, con))
        {
            cmd.Parameters.Add(new SqlParameter("@RFID", SqlDbType.VarChar).Value = RFID);
            cmd.Parameters.Add(new SqlParameter("@EID", SqlDbType.VarChar).Value = EID);
            //cmd.Parameters.AddWithValue("@EID", EID); //Or AddWithValue
            cmd.ExecuteNonQuery();
        }
    }
