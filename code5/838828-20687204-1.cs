        ///
        ///Converts a Dictionary of the given type to a DataTable
        ///		
		public static DataTable ConvertTo<T>(Dictionary<string, T> list, string dataTableName)
        {
            DataTable table = CreateTable1<T>(dataTableName);
            Type entityType = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);
            foreach (KeyValuePair<string, T> item in list)
            {
                DataRow row = table.NewRow();
				
                foreach (PropertyDescriptor prop in properties)
				{
					if (prop.PropertyType.FullName == "System.String")
					{
						if (prop.GetValue(item.Value) == null)
						{
							row[prop.Name] = prop.GetValue(item.Value);
						}
						else
						{
							row[prop.Name] = prop.GetValue(item.Value).ToString().Replace("'", "''");
						}
					}
					else
					{
						row[prop.Name] = prop.GetValue(item.Value);
					}
                }
                table.Rows.Add(row);
            }
            return table;
        }
		///
		/// Create a DataTable wich columns based on the properties of the given type <T>
		///
        public static DataTable CreateTable<T>(string dataTableName)
        {
            Type entityType = typeof(T);
            DataTable table = new DataTable(dataTableName);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);
			
            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            return table;
        }
