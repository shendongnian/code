        protected void FillEmployees()
        {
            var connectionString = "your_connection_string_from_config";
            using (var connection = new SqlConnection(connectionString))
            {
                using (var adapter = new SqlDataAdapter("Employees_Select", connection))
                {
                    connection.Open();
                    adapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    var ds = new System.Data.DataSet();
                    adapter.Fill(ds);
                    ddlEmp.DataSource = ds.Tables[0];
                    ddlEmp.DataBind();
                }
            }
        }
 
