    var scriptToExecute = new Dictionary<int, string>();
                var scriptToRollback = new Dictionary<int, string>();
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
                string rollbackScript = string.Empty;
                for (int i = scriptExecuting; i > 0; i--)
                {
                    scriptToRollback.TryGetValue(i, rollbackScript);
                    if (!string.IsEmpty(rollbackScript))
                    {
                        //Execute the scripts here.
                    }
                }
            }
            finally
            {
                //If connection is open then close the active connection
            }
