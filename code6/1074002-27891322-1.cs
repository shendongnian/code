    private bool PropertyIsReadable(IDataReader reader, string propertyName)
        {
            var result = false;
            for (var i = 0; i < reader.FieldCount; i++)
            {
                if (!reader.GetName(i).Equals(propertyName, StringComparison.InvariantCultureIgnoreCase))
                    continue;
                result = !reader[propertyName].Equals(DBNull.Value);
                break;
            }
            return result;
        }
