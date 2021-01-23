             try
             {
                 using (SqlCommand SqlCmd = new SqlCommand())
                 {
                     //Create User Script Execution
                     SqlCmd.CommandText = script1;
                     SqlCmd.Connection = oConnection;
                     lvinfo.Items.Add("Executing Create User script in " + dbname + " database");
                     var answer = SqlCmd.ExecuteNonQuery();
                     //Checking whether execution completed successfully
                     if (!answer.Equals(0))
                     {
                         lvinfo.Items.Add("Create User script executed successfully in " + dbname + " database");
                     }
                     else
                     {
                         lvinfo.Items.Add("Create User script execution failed in " + db_select.SelectedItem.ToString() + " database");
                     }
                 }
             }
             catch (SqlException)
             {
                 //Check if the connection is open , if not then open it
                 //create a bool script4Executing if you need to rollback only on script4
                 if (script4Executing)
                 {
                     //Write the DROP statements for all the CREATE LOGIN and USERS
                 }
             }
             finally
             {
                 //If connection is open then close the active connection
             }
