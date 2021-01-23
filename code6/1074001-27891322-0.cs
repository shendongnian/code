    public T GetEntity<T>(DbCommand command)
        {
            var instance = Activator.CreateInstance(typeof(T));
            var properties = typeof(T).GetProperties();
            using (var connection = Connection)
            {
                command.Connection = connection;
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        foreach (var property in properties.Where(property => property.CanWrite)
                            .Where(p => PropertyIsReadable(reader, p.Name)))
                        {
                            if (property.PropertyType == typeof(double))
                            {
                                property.SetValue(instance, reader.GetDouble(reader.GetOrdinal(property.Name)), null);
                                continue;
                            }
                            property.SetValue(instance, reader[property.Name], null);
                        }
                    }
                }
            }
            return (T)instance;
        }
