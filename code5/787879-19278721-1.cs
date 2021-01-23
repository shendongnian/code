    try
    {
         sqlitecon.Open();
         string Query = "Select dateopen, datejoin, title from Customer_New where Cust_Id=@id";
         SQLiteCommand createCommand = new SQLiteCommand(Query, sqlitecon);
         createCommand.Parameters.AddWithValue("@id", val);
         SQLiteDataReader dr = createCommand.ExecuteReader();
         while(dr.Read()){
            date_open.DisplayDate = dr.GetDateTime(0));
            Date_Joining.DisplayDate = dr.GetDateTime(1));     
            txt_Title.Text = dr.GetString(3);
        }                
        sqlitecon.Close();
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
