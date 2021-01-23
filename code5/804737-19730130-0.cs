    // Please don't actually format your code this way...
    var results = gridViewDataTable.AsEnumerable()
                      .GroupBy(
                          d => d.Field<string>("String1")
                      )
                      .Select(
                          g => g.OrderByDescending (
                              d => d.Field<string>("String2")
                            )
                      ) // Needed to close out the Select()
                      .CopyToDataTable();
    // How I would actually format this (makes it a little easier to
    // break down a single line):
    gridViewDataTable.AsEnumerable()
                     .GroupBy(d => d.Field<string>("String1"))
                     .Select(g => g.OrderByDescending(d => d.Field<string>("String2")))
                     .CopyToDataTable();
