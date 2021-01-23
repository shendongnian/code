    // Restore backup Code
            try
            {
                OpenFileDialog od = new OpenFileDialog();
                od.Filter = "SQL Server database Restore files|*.bak";
                od.Title = "Restore Database Backup";
                if (od.ShowDialog() == DialogResult.OK)
                {
                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString))
                    {
                            conn.Open();
                            string UseMaster = "USE master";
                            SqlCommand UseMasterCommand = new SqlCommand(UseMaster, conn);
                            UseMasterCommand.ExecuteNonQuery();
                            string Alter1 = @"ALTER DATABASE [Test_DB] SET Single_User WITH Rollback Immediate";
                            SqlCommand Alter1Cmd = new SqlCommand(Alter1, conn);
                            Alter1Cmd.ExecuteNonQuery();
                            string Restore = string.Format("Restore database Test_DB from disk='{0}'", od.FileName);
                            SqlCommand RestoreCmd = new SqlCommand(Restore, conn);
                            RestoreCmd.ExecuteNonQuery();
                            string Alter2 = @"ALTER DATABASE [Test_DB] SET Multi_User";
                            SqlCommand Alter2Cmd = new SqlCommand(Alter2, conn);
                            Alter2Cmd.ExecuteNonQuery();
                            conn.Close();
                               DevComponents.DotNetBar.MessageBoxEx.Show("Database Retored Sucessfully", "Success Message!");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Database didn't Restore", "Error Message!");
            }
