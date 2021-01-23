    public static DataTable toDataTable<T>(this IEnumerable<T> value, List<string> exclusionList)
            where T : class
        {
            var dataTable = new DataTable();
            var type = typeof(T);
            var properties = type.GetProperties().Where(x =>  !exclusionList.Contains(x.Name)).ToList();
            foreach (var propertyInfo in properties)
            {
                var propertyType = propertyInfo.PropertyType;
                if (!propertyType.IsScalar())
                    continue;
                var nullableType = Nullable.GetUnderlyingType(propertyType);
                propertyType = nullableType ?? propertyType;
                var dataColumn = new DataColumn(propertyInfo.Name, propertyType);
                if (nullableType != null)
                    dataColumn.AllowDBNull = true;
                dataTable.Columns.Add(dataColumn);
            }
            foreach (var row in value)
            {
                var dataRow = dataTable.NewRow();
                foreach (var property in properties)
                {
                    var safeValue = property.GetValue(row, null) ?? DBNull.Value;                    
                    dataRow[property.Name] = safeValue;
                }
                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }
