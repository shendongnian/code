        private void Button_add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string Query = @"INSERT INTO `bcasdb`.`tbl_department`(
                `dep_id`,
                `dep_name`,
                `tbl_branch_branch_id`) 
                VALUES (@depId, @depName, @branchId)";
                //This is command class which will handle the query and connection object.
                using (MySqlConnection conn = new MySqlConnection(BCASApp.DataModel.DB_CON.connection))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(Query, conn))
                    {
                        cmd.Parameters.Add("@depId", this.depIDInput.Text);
                        cmd.Parameters.Add("@dep_name", this.depnameInput.Text);
                        cmd.Parameters.Add("@branchId", this.dep_branchIDInput.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                successmsgBox();
            }
            catch (Exception)
            {
                errormsgBox();
            }
        }
