    using (SqlConnection connection = new SqlConnection())
        {
            string connectionStringName = this.DataWorkspace.AdventureWorksData.Details.Name;
            connection.ConnectionString =
                ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            string procedure = "HumanResources.uspUpdateEmployeePersonalInfo";
            using (SqlCommand command = new SqlCommand(procedure, connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(
                    new SqlParameter("@EmployeeID", entity.EmployeeID));
                command.Parameters.Add(
                    new SqlParameter("@NationalIDNumber", entity.NationalIDNumber));
                command.Parameters.Add(
                    new SqlParameter("@BirthDate", entity.BirthDate));
                command.Parameters.Add(
                    new SqlParameter("@MaritalStatus", entity.MaritalStatus));
                command.Parameters.Add(
                    new SqlParameter("@Gender", entity.Gender));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
 
