    dt.Columns.OfType<DataColumn>()
              .Where(c=>!dt.Rows.OfType<DataRow>()
                                .Any(r=>r.Field<string>(c.ColumnName) != ""))
              .ToList()
              .ForEach(c=>dt.Columns.Remove(c));
    //Remove rows
    dt.Rows.OfType<DataRow>()
           .Where(r=>!dt.Columns.OfType<DataColumn>()
                                .Any(c=>r.Field<string>(c.ColumnName) != ""))
           .ToList()
           .ForEach(r=>dt.Rows.Remove(r));
