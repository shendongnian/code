    String myConnectionString = ".....";
    string querySel = @"SELECT [Username],[Calories Burnt] 
                        FROM tblTrainingInformation 
                        WHERE [Username] = @uname";
    using(OleDbConnection myConnection = new OleDbConnection(myConnectionString))
    using(OleDbCommand myCommand = new OleDbCommand(querySel, myConnection))
    {
        myConnection.Open(); 
        myCommand.Parameters.AddWithValue("@uname", GlobalUsername.username);
        using(OleDbDataReader reader = myCommand.ExecuteReader())
        {
            int calories = 0;
            string query = "";
            if(reader.Read())
            {
                // The record exists, read the calories and add the new value
                // then execute the UPDATE 
                calories = Convert.ToInt32(reader["Calories Burnt"]);
                calories += Convert.ToInt32(this.txtCaloriesBurntRun.Text);
                query = @"UPDATE tblTrainingInformation 
                          SET [Calories Burnt] = @cal
                          WHERE [Username] = @uname";
            }
            else
            {
                // Record doesn't exist, INSERT the new data
                calories = Convert.ToInt32(this.txtCaloriesBurntRun.Text);
                query = @"INSERT INTO tblTrainingInformation 
                          ([Calories Burnt],[Username])
                          VALUES(@cal, @uname)";
            }
            reader.Close();
            myCommand.Parameters.Clear();
            myCommand.Parameters.AddWithValue("@cal", calories);
            myCommand.Parameters.AddWithValue("@uname", GlobalUsername.username);
            myCommand.ExecuteNonQuery();
            MessageBox.Show("Your running information has been saved");
        }
    }
