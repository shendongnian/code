    DataTable result;
    if(linqdt.Columns[options.SelectedColumn].DataType == typeof(string))
    
        result = linqdt.AsEnumerable()
                       .Where(w => (w.Field<string>(options.SelectedColumn))
                                     .Contains(options.Value))
                       .CopyToDataTable();
    else
        result = linqdt.AsEnumerable()
                       .Where(w => (w[options.SelectedColumn]).Equals(options.Value))
                       .CopyToDataTable();
