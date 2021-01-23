    using(SqlConnection conn = new SqlConnection(Properties.Settings.Default.CategoriesConnectionString))
    using(SqlCommand chkUser = new SqlCommand("SELECT [Username] FROM [Accounts] WHERE [Username] = @username", conn))
    {
      chkUser.Parameters.AddWithValue("@username", txtUsername.Text);
      
      try
      {
        conn.Open();
        
        using(SqlDataReader sqlReader = chkUser.ExecuteReader()) 
        {
          if (sqlReader.HasRows)
          {
            MessageBox.Show("That username already exists.  Please choose another.");
            txtUsername.Focus();
            return;
          }
        }
      }
      catch(Exception e)
      {
        // manage exception  
      }
    }
