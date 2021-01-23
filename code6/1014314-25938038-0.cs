        int myPK;
        var command1 = "INSERT INTO [Time] ([Start Time], [Work Order]) OUTPUT INSERTED.PrimaryKey VALUES (@StartTime, @Work_Order)";
        using (SqlConnection cnn1 = new SqlConnection(cnnString))
        {
            using (SqlCommand cmd1 = new SqlCommand(command1, cnn1))
            {
                cmd1.Parameters.AddWithValue("@StartTime", SqlDbType.DateTime).Value = System.DateTime.Now;
                cmd1.Parameters.AddWithValue("@Work_Order", SqlDbType.Int).Value = e.CommandArgument;
                cnn1.Open();
                myPk = Convert.ToInt32(cmd1.ExecuteScalar());
                Label1.Text = myPk.ToString();
                cnn1.Close();
            }
        }
        var command = "UPDATE [Time] SET [Stop Time] = @StopTime WHERE [PrimaryKey] = @PrimaryKey";
        using (SqlConnection cnn = new SqlConnection(cnnString))
        {
            using (SqlCommand cmd = new SqlCommand(command, cnn))
            {
                cmd.Parameters.AddWithValue("@StopTime", SqlDbType.DateTime).Value = System.DateTime.Now;
                cmd.Parameters.AddWithValue("@PrimaryKey", myPK);
                FindControl("Work_OrderLabel"); ;
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }
