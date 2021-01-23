        public static DataSet GetDataSet(List<string> title, IEnumerable<IEnumerable> data)
        {
            DataSet ds = new DataSet();
            int idx = 0;
            foreach (var item in data)
            {
                //here I get compile time error "The type arguments for method
                // 'ExportToExcel.CreateExcelFile.ListToDataTable<T>
                // (System.Collections.Generic.List<T>)' cannot be inferred from the usage.
                // Try specifying the type arguments explicitly. "
                var dt = Util.ListToDataTable(item);
                if (title.Count >= idx)
                {
                    dt.TableName = title[idx];
                }
                idx++;
                ds.Tables.Add(dt);
            }
            return ds;
        }
        public static System.Data.DataTable ListToDataTable(IEnumerable list)
        {
            var dt = new System.Data.DataTable();
            var itm = list.OfType<object>().FirstOrDefault();
            if (itm == null)
                return dt;
            var typeProperties = itm.GetType().GetProperties();
            foreach (PropertyInfo info in typeProperties)
            {
                dt.Columns.Add(new DataColumn(info.Name, info.PropertyType));
            }
            foreach (var t in list)
            {
                DataRow row = dt.NewRow();
                foreach (PropertyInfo info in typeProperties)
                {
                    row[info.Name] = info.GetValue(t, null);
                }
                dt.Rows.Add(row);
            }
            return dt;
        }
