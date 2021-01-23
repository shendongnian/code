    List<whatever> src = new List<whatever>();
    GridView1.DataSource = EnumerableToTable(src);
__
    public static DataTable EnumerableToTable<T>(IList<T> li, PropertyType pt = PropertyType.Named)
        {
            DataTable table = EmptyTable<T>(pt);
            PopulateTableFromList<T>(table, ref li);
            return table;
        }
        public static void PopulateTableFromList<T>(DataTable table, ref IList<T> li, PropertyType pt = PropertyType.Named)
        {
            foreach (T obj in li)
            {
                List<PropertyInfo> propList = typeof(T).GetProperties().ToList();
                DataRow dr = table.NewRow();
                foreach (PropertyInfo prop in propList)
                {
                    if (Attribute.IsDefined(prop, typeof(DisplayNameAttribute)))
                    {
                        dr.SetField(prop.GetCustomAttributes(typeof(DisplayNameAttribute), false).Cast<DisplayNameAttribute>().Single().DisplayName, prop.GetValue(obj));
                    }
                    //else
                    //{
                    //    dr.SetField(prop.Name, prop.GetValue(obj));
                    //}
                }
                table.Rows.Add(dr);
            }
        }
        public static DataTable EmptyTable<T>(PropertyType pt = PropertyType.Named)
        {
            //Create DataTable from list object's properties
            DataTable table = new DataTable();
            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                if (pt != PropertyType.Browsable || !(Attribute.IsDefined(prop, typeof(BrowsableAttribute)) && !prop.GetCustomAttributes(typeof(BrowsableAttribute), false).Cast<BrowsableAttribute>().Single().Browsable))
                {
                    if (Attribute.IsDefined(prop, typeof(DisplayNameAttribute)))
                    {
                        if (!prop.PropertyType.Name.ToLower().Contains("null"))
                        {
                            table.Columns.Add(prop.GetCustomAttributes(typeof(DisplayNameAttribute), false).Cast<DisplayNameAttribute>().Single().DisplayName, prop.PropertyType);
                        }
                        else
                        {
                            table.Columns.Add(prop.GetCustomAttributes(typeof(DisplayNameAttribute), false).Cast<DisplayNameAttribute>().Single().DisplayName, prop.PropertyType.GenericTypeArguments[0]);
                        }
                    }
                    else if (pt != PropertyType.Named)
                    {
                        if (!prop.PropertyType.Name.ToLower().Contains("null"))
                        {
                            table.Columns.Add(prop.Name, prop.PropertyType);
                        }
                        else
                        {
                            table.Columns.Add(prop.Name, prop.PropertyType.GenericTypeArguments[0]);
                        }
                    }
                }
            }
            return table;
        }
