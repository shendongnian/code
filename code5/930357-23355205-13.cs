    private void btnInsertHobbies_Click(object sender, EventArgs e)
        {
            int userID=0;
            if(Session["UserID"]!=null)
            {
              userID=Convert.ToInt32(Session["UserID"]);
            }
            
            //add Here fields of hobbies table
            string hobby1= textBox2.Text;
            string hobby2= textBox3.Text;
            if (conn2.State != ConnectionState.Open)
            {
               conn2.Close();
               conn2.Open();
            }
                
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn2;
            cmd.CommandText = "INSERT INTO Hobbies(userID, hobby1, hobby2)   VALUES(@userID,@hobby1,@hobby2)";
    
            cmd.Parameters.AddWithValue("@userID", userID);
            cmd.Parameters.AddWithValue("@hobby1", hobby1);
            cmd.Parameters.AddWithValue("@hobby2", hobby2);
    
            cmd.ExecuteNonQuery(); 
    
            conn2.Close();
        }
