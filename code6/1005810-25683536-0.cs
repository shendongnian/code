    public List<T> ReadData<T>(string queryString)
            {
                using (var connection =
                           new SqlConnection(constr))
                    using (var command =
                        new SqlCommand(queryString, connection))
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                            if (reader.HasRows)
                                return Mapper.DynamicMap<IDataReader, List<T>>(reader);
                    }
                return null;
            }
