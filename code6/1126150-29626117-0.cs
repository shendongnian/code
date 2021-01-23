    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SOMECONNECTIONNAME"]);
                connection.Open();
    SqlCommand command = new SqlCommand("NoInstallationNemIdLog", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DateFrom", DBNull.Value);
                    command.Parameters.AddWithValue("@DateTo", DBNull.Value);
                    SqlDataReader DR = command.ExecuteReader();
