    public static class CsvHelperExtensions
    {
        public static CsvPropertyMap Required<T>(this CsvPropertyMap map, string columnName)
        {
            return map.Name(columnName).ConvertUsing(row =>
            {
                if (string.IsNullOrEmpty(row.GetField(columnName)))
                    throw new CsvParserException($"{columnName} is required, but missing from row {row.Row}");
                return row.GetField<T>(columnName);
            });
        }
    }
