    public static class ConvertToDatatable
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null) throw new ArgumentException("enumerable");
            var dt = new DataTable();
            var es = enumerable as List<T> ?? enumerable.ToList();
            var first = es.First();
            if (first != null)
            {
                var props = first.GetType().GetProperties();
                foreach (var propertyInfo in props)
                {
                    if (!propertyInfo.PropertyType.IsClass || propertyInfo.PropertyType.Name.Equals("String"))
                    {
                        dt.Columns.Add(new DataColumn(propertyInfo.Name));
                    }
                }
            }
            foreach (var e in es)
            {
                var props = e.GetType().GetProperties();
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                foreach (var propertyInfo in props)
                {
                    if (!propertyInfo.PropertyType.IsClass || propertyInfo.PropertyType.Name.Equals("String"))
                    {
                        dr[propertyInfo.Name] = propertyInfo.GetValue(e);
                    }
                }
            }
            return dt;
        }
