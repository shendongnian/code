            foreach (System.Data.DataRow row in schema.Rows)
            {
    
            currentTableName = row["TABLE_NAME"].ToString();
            currentTableName = currentTableName = currentTableName.Replace(" ", "");
            currentTableName = currentTableName.Replace("[", "");
            currentTableName = currentTableName.Replace("]", "");
    
            command.CommandText = selectQuery.Replace("@tableName", row["TABLE_NAME"].ToString());
            ad.FillSchema(ds, SchemaType.Mapped, row["TABLE_NAME"].ToString());
    
            foreach (DataColumn dc in ds.Tables[row["TABLE_NAME"].ToString()].Columns)
                {
                var typeName = dc.DataType.Name;
                var propName = dc.ColumnName.Replace(dc.ColumnName[0].ToString(), dc.ColumnName[0].ToString().ToLower());
                propName = propName.Replace(" ", "");
               }
    
                }
