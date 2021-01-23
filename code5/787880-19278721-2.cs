    try
    {
         sqlitecon.Open();
         string Query = "Select dateopen, datejoin, title from Customer_New where Cust_Id=@id";
         SQLiteCommand createCommand = new SQLiteCommand(Query, sqlitecon);
         createCommand.Parameters.AddWithValue("@id", val);
         SQLiteDataReader dr = createCommand.ExecuteReader();
         while(dr.Read())
         {
            // If there is the possibility of a NULL field then protect the assignement
            // with a check for DBNull.Value before the assignement
            if(!dr.IsDBNull(0))
                date_open.DisplayDate = dr.GetDateTime(0));
            if(!dr.IsDBNull(1))
                Date_Joining.DisplayDate = dr.GetDateTime(1));     
            if(!dr.IsDBNull(2))
                txt_Title.Text = dr.GetString(2);
        }                
        sqlitecon.Close();
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
