    public static void BulkInsertBigData<T>(Table<T> definition, IEnumerable<T> rows)
    {
        using (var copy = new SqlBulkCopy(definition.Context.Connection.ConnectionString, SqlBulkCopyOptions.KeepIdentity | SqlBulkCopyOptions.KeepNulls))
        {
            var meta = definition.Context.Mapping.GetMetaType(typeof(T));
            foreach (var col in meta.DataMembers)
            {
                copy.ColumnMappings.Add(col.Member.Name, col.MappedName);
            }
            copy.DestinationTableName = meta.Table.TableName;
            var data = rows.ToDataTable();
            copy.WriteToServer(data);
        }
    }
