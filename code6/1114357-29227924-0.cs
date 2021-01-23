    var list = new[]
                               {
                                   new { Id = 1, Month = 2, Commodity = "Wheat", Amount = 20 },
                                   new { Id = 2, Month = 2, Commodity = "Maize", Amount = 30 },
                                   new { Id = 3, Month = 2, Commodity = "Barley", Amount = 30 },
                                   new { Id = 4, Month = 1, Commodity = "Wheat", Amount = 20 },
                                   new { Id = 5, Month = 1, Commodity = "Maize", Amount = 30 },
                                   new { Id = 6, Month = 3, Commodity = "Barley", Amount = 30 }
                               };
    
                // group data by month and keep all rows
                var data =
                    list.GroupBy(r => r.Month)
                        .Select(
                            r =>
                            new 
                                {
                                    Month = r.Key,
                                    Data = r.ToList()
                                })
                        .ToList();
    
                // get a list of all available commodities
                var allColumns = data.SelectMany(d => d.Data.Select(s => s.Commodity)).Distinct().ToList();
                    
                // create a table
                var datatable = new DataTable();
                datatable.Columns.Add(new DataColumn("Month"));
    
                // add all commodities as columns
                allColumns.ForEach(c=>datatable.Columns.Add(new DataColumn(c)));
    
                // create 1 row for each month group and fill the columns
                data.ForEach(
                    d =>
                        {
                            var row = datatable.NewRow();
                            row["Month"] = d.Month;
                            allColumns.ForEach(c => row[c] = d.Data.Where(g => g.Commodity == c).Sum(g => g.Amount));
                            datatable.Rows.Add(row);
                        });
