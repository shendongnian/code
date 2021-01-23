    Object[] result = new object[tmp.Count];
    int i = 0;
    result = tmp.Table
                .AsEnumerable()
                .ForEach(row => result[i++] = new Object[] { row.Field<DateTime>("DATE"),
                                                Convert.ToDouble(row.Field<string>("VALUE"))});
