               using (_connection)
                {
                    reader = command.ExecuteReader();
                    fieldCount = reader.FieldCount;
                    properties = new SortedList<string, PropertyInfo>();
                    foreach (PropertyInfo pi in typeof(T).GetProperties())
                    {
                        properties.Add(pi.Name.ToUpper(), pi);
                    }
                    while (reader.Read())
                    {
                        T item = Activator.CreateInstance<T>();
                        for (int i = 0; i < fieldCount; i++)
                        {
                            if (reader[i] != DBNull.Value)
                                properties[reader.GetName(i).ToUpper()].SetValue(item, reader[i], null);
                        }
                        entitySet.Add(item);
                    }
                }
                reader.Close();
