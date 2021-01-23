    var dt = new DataTable();
    dt.Columns.Add("Amount", typeof(int));
    dt.Columns.Add("Count", typeof(int));
    dt.Rows.Add(20, 2);
    dt.Rows.Add(42, 1);
    dt.Rows.Add(78, 5);
    dt.Rows.Add(91, 2);
    var result = from DataRow x in dt.Rows
                    group x by ((int)x["Amount"]) / 50 into grp 
                    select new {LowerBoundIncl = grp.Key * 50, 
                            UpperBoundExcl = (grp.Key + 1) * 50, 
                            TotalCount = grp.Sum(y => (int) y["Count"])};
