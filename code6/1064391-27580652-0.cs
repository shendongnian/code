    public List<T> ReturnList<T>(CommandType commandType, string commandText, List<SqlParameter> parameters) where T : new()
        {
            SqlDataReader reader = null;
            try
            {
                CreateConnection();
                command = new SqlCommand();
                BuildCommand(command, commandType, commandText, conn);
                AddParametersToCommand(parameters, command);
                reader = command.ExecuteReader();
                List<T> list = CommonMethods.ToList<T>(reader);
                reader.Close();
                reader.Dispose();
                CloseConnection();
                return list;
            }
            catch (Exception ex)
            {
                reader.Close();
                reader.Dispose();
                conn.Close();
                throw ex;
            }
            finally
            {
            }
            
        }
