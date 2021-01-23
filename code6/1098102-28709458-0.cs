       public static DataTable GetDataTableFromSchema(string userDefinedTableTypeName, SqlConnection connection)
        {
            var query = "SELECT SC.name, ST.name AS datatype FROM sys.columns SC " +
                        "INNER JOIN sys.types ST ON ST.system_type_id = SC.system_type_id AND ST.is_user_defined = 0 " +
                        "WHERE SC.object_id = " +
                        "   (SELECT type_table_object_id FROM sys.table_types WHERE name = '" + userDefinedTableTypeName + "');";
            var dataTable = new DataTable();
            using (var command = new SqlCommand(query, connection))
            {
                using (var sqlDataReader = command.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        var columnName = sqlDataReader["name"].ToString();
                        var sqlDbType = (SqlDbType) Enum.Parse(typeof (SqlDbType), sqlDataReader["datatype"].ToString(), true);
                        var clrType = GetClrType(sqlDbType);
                        dataTable.Columns.Add(columnName, clrType);
                    }
                }                
            }
            return dataTable;
        }
