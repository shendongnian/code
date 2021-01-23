    result = tmp.Table
                .AsEnumerable()
                .Select(row => (Object)new Object[] { row.Field<DateTime>("DATE"),
                                                Convert.ToDouble(row.Field<string>("VALUE"))})
                .ToArray();
