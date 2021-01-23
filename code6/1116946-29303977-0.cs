    private void InsertRecord(string teacher, string grade)
    {
        string insertstatement = "INSERT INTO tbl_TeacherInfo (Teacher,Grade) VALUES (@Teacher, @Grade)";
        
        using (SqlConnection conn = new SqlConnection(connString))
        {
            using (SqlCommand comm1 = new SqlCommand(insertstatement, conn))
            {
                conn.Open();
                comm1.Parameters.AddWithValue("@Teacher", teacher);
                comm1.Parameters.AddWithValue("@Grade", grade);
                comm1.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
