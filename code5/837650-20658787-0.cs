        try
        {
            using (SqlConnection sql = new SqlConnection(connection))
            {
                sql.Open();
                string query = "SELECT * FROM dbo.Login WHERE username = @login";
                SqlCommand selectLogin = new SqlCommand(query , sql);
                selectLogin.Parameters.Add(new SqlParameter("@login",login)); 
                SqlDataReader readerLogin = selectLogin.ExecuteReader())                    
                while (readerLogin.Read())
                {
                   if (readerLogin.IsDBNull(0) || readerLogin.IsDBNull(2))
                      continue;
                   loginVal = readerLogin.GetString(0);
                   passwordVal = readerLogin.GetString(2);
                }
           }
        }
