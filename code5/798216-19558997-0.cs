            try
            {
                con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand(cmdString, con, transaction);
                cmd.Parameters.AddWithValue("@PatientID", p.HospitalNo);
                // Continue your usual work
                cmd.Parameters.AddWithValue("@Remark", dummmy);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
            }
            finally
            {
                con.Close();
            }
