    var rows = dt.AsEnumerable()
                        .Select(s =>
                            new
                            {
                                ID = s.Field<int>("ID"),
                                Date = s.Field<DateTime>("Date"),
                                ValueA = s.Field<int>("ValueA")
                            })
                        .GroupBy(
                            key => new { key.ID, key.Date },
                            (key, agg) =>
                            new
                            {
                                key.ID,
                                key.Date,
                                ValueA = agg.Max(a => a.ValueA) // etc.
                            });
                         
            var grouped = new DataTable("grouped");
            foreach (var r in rows)
            {
                var row = grouped.NewRow();
                // Put the rows that are now as you want them back into a datatable
                grouped.Rows.Add(row);
            }
