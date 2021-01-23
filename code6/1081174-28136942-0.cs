    void approval()
        {
            if (yes)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
                SqlCommand com = conn.CreateCommand();
                conn.Open();
                com.Parameters.Clear();
                com.CommandText = "UPDATE [Marking] SET [acceptance]=@acc where [class_id]=@cid AND [module_id]=@mid AND [student_id]=@sid";
                com.Parameters.Add("@acc", SqlDbType.VarChar).Value =
                com.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                //Cancel the process
            }
