    int i = 1;
    
    private void PinError()
    {
         if(i != 3)
         {
             MessageBox.Show("Invalid Pin. Pin Will Change After " + (3 - i) + " More Attempts");
             i++;
             return;
         }
         
         string strConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
         SqlConnection myConnect = new SqlConnection(strConnectionString);
         SqlCommand cmd = new SqlCommand("Update PostParcel set Pin=@pin1 where Box='1'and Pin!= '' ", myConnect);
         cmd.Parameters.AddWithValue("@pin1", RandomNumber(1000, 9999));
         myConnect.Open();
         cmd.ExecuteNonQuery();
         myConnect.Close();
         MessageBox.Show("Invalid Pin. New Pin Has Been Sent");
    }
