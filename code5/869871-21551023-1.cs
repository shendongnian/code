     public void Delete(string id)
        {
            CMD.Parameters.Clear();
            CMD.CommandText = "SP name";
            CMD.Parameters.AddWithValue("@ID", id);
            try
            {
                CON.Open();
                CMD.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException);
            }
            finally
            {
                CON.Close();
            }
        }
