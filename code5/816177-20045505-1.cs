    public static void BulkInsertBigData<T>(Table<T> definition, IEnumerable<T> rows)
    {
        using (var copy = new SqlBulkCopy(definition.Context.Connection.ConnectionString, SqlBulkCopyOptions.KeepIdentity | SqlBulkCopyOptions.KeepNulls))
        {
            var meta = definition.Context.Mapping.GetMetaType(typeof(T));
            var members = new List<string>(meta.DataMembers.Count);
            foreach (var col in meta.DataMembers)
            {
                copy.ColumnMappings.Add(col.Member.Name, col.MappedName);
                members.Add(col.Member.Name);
            }
            copy.DestinationTableName = meta.Table.TableName;
            using (var reader = ObjectReader.Create(rows, members.ToArray()))
            {
                copy.WriteToServer(reader);
            }
        }
    }
