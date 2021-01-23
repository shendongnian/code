    using (StreamReader sr = new StreamReader(filePath))
    {
       while (!sr.EndOfStream)
       {
           var readLine = sr.ReadLine();
           if (readLine != null)
           {
              string[] strings = readLine.Split('-');
              using (SqlConnection sqlCon2 = new SqlConnection("REMOVED"))
              {
                 using (SqlCommand sqlCmd2 = new SqlCommand { CommandText = "INSERT INTO [Products].[Features] ([ProductID] ,[Title] ,[ViewOrder]) VALUES ('" + strings[0] + "', '" + strings[1] + "', NULL) ", Connection = sqlCon2 })
                 {
                    sqlCon2.Open();
                    sqlCmd2.ExecuteNonQuery();
                 }
               }
            }
        }
      }
