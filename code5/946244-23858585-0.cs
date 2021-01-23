        public static IEnumerable<T> GetStoredProcedure<T>(string procedure) where T : new()
        {
            var data = new List<T>();
            using (var conn = new SqlConnection(_connectionString))
            {
                var com = new SqlCommand();
                com.Connection = conn;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = procedure;
                var adapt = new SqlDataAdapter();
                adapt.SelectCommand = com;
                var dataset = new DataSet();
                adapt.Fill(dataset);
                //Get each row in the datatable
                foreach (DataRow row in dataset.Tables[0].Rows)
                {
                    //Create a new instance of the specified class
                    var newT = new T();
                    //Iterate each column
                    foreach (DataColumn col in dataset.Tables[0].Columns)
                    {
                        //Get the property to set
                        var property = newT.GetType().GetProperty(col.ColumnName);
                        //Set the value
                        property.SetValue(newT, row[col.ColumnName]);
                    }
                    //Add it to the list
                    data.Add(newT);
                }
                return data;
            }
        }
