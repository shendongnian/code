        public Class1(DataTable dt, DataRow row)
        {
            if (dt.Columns.Contains("id"))
                id = row.Field<string>("id");
            if (dt.Columns.Contains("name"))
                name = row.Field<string>("name");
        }
        IList<Class1> items = dt.AsEnumerable().Select(row => new Class1(dt, row)).ToList();
