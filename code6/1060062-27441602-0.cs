     private void restoreBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (databaseCmbBox.Text.CompareTo("") == 0)
                {
                    MessageBox.Show("Please Select A Database");
                    return;
                }
                con = new SqlConnection(connectionString);
                con.Open();
                sql = "ALTER DATABASE " + databaseCmbBox.Text  +" SET Single_User WITH Rollback Immediate ; RESTORE DATABASE " +
                databaseCmbBox.Text + " FROM DISK = @PATH WITH REPLACE ; ALTER DATABASE " + databaseCmbBox.Text + " SET Multi_User ;";
                comm.CommandTimeout = 86400000;
    
    
                //sql = "Alter Database "+databaseCmbBox.Text+" Set SINGLE_USER WITH ROLLBACK IMMEDIATE";
                //sql += "RESTORE Database " + databaseCmbBox.Text + " FROM DISK = '" + databaseRestorePath.Text + "' WITH REPLACE";
                comm = new SqlCommand(sql, con);
                comm.Parameters.AddWithValue("@PATH", databaseRestorePath.Text);
                comm.ExecuteNonQuery();
    
                con.Close();
                con.Dispose();
                MessageBox.Show("Database Succesfully Restored");
    
            }
            catch (Exception)
            {
    
                throw;
            }
