            SqlConnection cnn;
            SqlCommand cmd;
            cnn = new SqlConnection(textDataSource);
            cmd = new SqlCommand(sql, cnn);
            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cmd.Dispose();
                cnn = null;
                cmd = null; 
            }
        }
