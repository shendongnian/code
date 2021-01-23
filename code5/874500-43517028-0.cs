     public DataTable ToDataTable<T>(dynamic items)
        {
            DataTable dtDataTable = new DataTable();
            if (items.Count == 0) return dtDataTable;
            ((IEnumerable)items[0]).Cast<dynamic>().Select(p => p.Name).ToList().ForEach(col => { dtDataTable.Columns.Add(col); });
            ((IEnumerable)items).Cast<dynamic>().ToList().
                ForEach(data =>
                {
                    DataRow dr = dtDataTable.NewRow();
                    ((IEnumerable)data).Cast<dynamic>().ToList().ForEach(Col => { dr[Col.Name] = Col.Value; });
                    dtDataTable.Rows.Add(dr);
                });
            return dtDataTable;
        }
