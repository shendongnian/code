    const int cols = 6;
    const int rows = 20;
    
    DataTable nt = new DataTable("new table");
    
    nt.Columns
      .AddRange(
         Enumerable
          .Range(1,cols)
          .Select(x => new DataColumn("col"+x.ToString())).ToArray());
    
    Enumerable
     .Range(1,rows).ToList()
     .ForEach(x => nt.Rows
                     .Add(
                      Enumerable
                      .Range(1,cols)
                      .Select(y => "row"+x.ToString()+"col"+y.ToString()).ToArray()));
    
