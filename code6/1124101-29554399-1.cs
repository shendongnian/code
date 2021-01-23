            DataTable dt;
            using (SqlConnection c = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM [dbo].[Dealer]", c))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dt = ds.Tables[0];
                }
            }
            dt.Rows[0].Delete();
            dt.Rows[1].Delete();
            dt.Rows[2].Delete();
            using (SqlConnection c = new SqlConnection(connectionString))
            {
                var adapter = new SqlDataAdapter();
                var command = new SqlCommand("DELETE FROM Dealer WHERE DealerId = @DealerId;", c);
                var parameter = command.Parameters.Add("@DealerId", SqlDbType.Int, 3, "DealerId");
                parameter.SourceVersion = DataRowVersion.Original;
                adapter.DeleteCommand = command;
                adapter.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
                adapter.UpdateBatchSize = 2;
                adapter.Update(dt);
            }
