    public bool IsChanged(DataTable original, DataTable source, string idKeyName, params string[] ignoreColumns)
    {
        // make sure "key" column exist in both
        if (!original.Columns.Contains(idKeyName) || !source.Columns.Contains(idKeyName))
        {
            throw new MissingPrimaryKeyException("Primary key column not found.");
        }
        // if source rows are not the same as original then something was deleted or added
        if (source.Rows.Count != original.Rows.Count)
        {
            return false;
        }
        // Get a list of columns ignoring passed in and key (key will have to be equal to find)
        var originalColumns =
            original.Columns.Cast<DataColumn>()
                    .Select(c => c.ColumnName)
                    .Where(n => !ignoreColumns.Contains(n) && n != idKeyName)
                    .ToArray();
        // check to make sure same column count otherwise just fail no need to check
        var sourceColumnsCount =
            source.Columns.Cast<DataColumn>()
                  .Select(c => c.ColumnName).Count(originalColumns.Contains);
        if (originalColumns.Length != sourceColumnsCount)
        {
            return false;
        }
        //Switch to linq
        var sourceRows = source.AsEnumerable();
        return sourceRows.All(sourceRow =>
            {
                // use select since not real key
                var originalCheck = original.Select(idKeyName + " = " + sourceRow[idKeyName]);
                if (originalCheck.Length != 1)
                {
                    // Couldn't find key or multiple matches
                    return false;
                }
                var originalRow = originalCheck.First();
                //Since using same array we can use linq's SequenceEqual to compare for us
                return
                    originalColumns.Select(oc => sourceRow[oc])
                                   .SequenceEqual(originalColumns.Select(oc => originalRow[oc]));
            });
    }
