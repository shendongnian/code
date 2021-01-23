    var result = (from A1 in dt1.AsEnumerable()
                              join
                                 A2 in dt2.AsEnumerable()
                              on
                                 A1.Field<string>("TEST2") equals (A2.Field<string>("TEST2") + "-" + A2.Field<string>("TEST5") + (A2.Field<string>("TEST6") == string.Empty ? "-" : string.Empty) + A2.Field<string>("TEST6"))
                              select new { 
                                    TEST2 = A1.Field<string>("TEST2"), 
                                    x1 = A1.Field<string>("TEST3"), 
                                    x2 = A2.Field<string>("TEST7")
                              });
    
                DataTable dtFinal = LINQToDataTable(result);
