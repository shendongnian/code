    protected void Button1_Click(object sender, EventArgs e)
            {
                string type = DropDownList1.SelectedItem.ToString();
                string name = TextBox2.Text;
                string nop = DropDownList2.SelectedItem.ToString();
                int num = int.Parse(nop);
                string connectionString = WebConfigurationManager.ConnectionStrings["HMSConnectionString"].ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);
                
        		 SqlConnection db = new SqlConnection("connstringhere");
              SqlTransaction transaction;
        
              db.Open();
              transaction = db.BeginTransaction();
              try 
              {
                 new SqlCommand("Get count of available room (If greater then selected numbers of rooms)", db, transaction)
                    .ExecuteNonQuery();
                 new SqlCommand("Insert name and no of rooms (new record in table)", db, transaction)
                    .ExecuteNonQuery();
                 new SqlCommand("Update rooms table (subtract by no of rooms )", db, transaction)
                    .ExecuteNonQuery();
                 transaction.Commit();
        		    Label5.Text = "Reserved for"+name;
              } 
              catch (SqlException sqlError) 
              {
                 transaction.Rollback();
              }
              db.Close();
              
            }
