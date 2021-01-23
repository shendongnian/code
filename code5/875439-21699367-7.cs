    Dictionary<Tuple<int, string>, List<Data>> allData = data.AsEnumerable()
        .GroupBy(r => new { RowID = r.Field<int>("RowID"), FieldName = r.Field<string>("FieldName") })
        .ToDictionary(
            g => Tuple.Create(g.Key.RowID, g.Key.FieldName), 
            g => g.Select(r => new Data
                {
                RowID = g.Key.RowID,
                FieldName = g.Key.FieldName,
                FieldID = r.Field<int>("RowID"),
                ID = r.Field<int>("ID"),
                RecordFieldData = r.Field<int>("RecordFieldData"),
                RecordID = r.Field<int>("RecordID")
            })
            .ToList());
    // lookup with RowId + FieldName, f.e.:
    List<Data> datas;
    if(allData.TryGetValue(Tuple.Create(1, "name"), out datas))
    {
        // dictionary contains this data
    }
