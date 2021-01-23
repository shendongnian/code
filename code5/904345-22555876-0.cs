     using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    My_Event _event = new My_Event();
                    if (reader["Id"] != DBNull.Value) { _event.ID = (int)reader["Id"]; }
                    if (reader["site"] != DBNull.Value) { _event.Site = reader["site"].ToString(); }
                    if (reader["time"] != DBNull.Value) { _event.Time = (DateTime)reader["time"]; }
                       _events.AddFirst(_event);
                }
                reader.Close();
            }
