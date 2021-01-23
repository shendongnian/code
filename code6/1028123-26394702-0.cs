        string URL = Path.GetFileName(Request.Path);  
        string sqlIns = "INSERT INTO table (url) VALUES (@url)";
            
            db.Open();
            try
            {
            SqlCommand cmdIns = new SqlCommand(sqlIns, db.Connection);
            cmdIns.Parameters.Add("@url", URL);
            
            cmdIns.ExecuteNonQuery();
            cmdIns.Dispose();
            cmdIns = null;
            }
            catch(Exception ex)
            {
            throw new Exception(ex.ToString(), ex);
            }
            finally
            {
            db.Close();
            }
