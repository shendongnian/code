        public static void ConfigureSQL(ServerProfile server, CustomerProfile customer)
        {
            try
            {
                if(IsDatabaseInExistence(server.TemplateName) == true)
                    CreateSQLDatabase(customer.WebAddress);
                if(IsDatabaseInExistence(customer.WebAddress) == true)
                {
                    RestoreSQLDatabase(server.TemplateName, customer.WebAddress);
                    InputCustomerProfileToSQL(customer.FirstName, customer.LastName, customer.EmailAddress, customer.UserName, customer.WebAddress);
                }
                
            }
            catch(SqlException ex)
            {
                SqlExceptionHelper.GetSQLExceptionDescription(ex);
            }
        }
