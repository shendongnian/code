    var cache = new Dictionary<string,Func<T,object>>();
    foreach (var item in t) {
        var dr = dataTable.NewRow();
        for (var i = 0; i < dataTable.Columns.Count; i++) {
            var el = columnNames.ElementAtOrDefault(i);
            if (el == null) {
                dr[i] = DBNull.Value;
            } else {
                dr[i] = GetValueGetter<T>(item, el, cache);
            }
        }
        dataTable.Rows.Add(dr);
    }
