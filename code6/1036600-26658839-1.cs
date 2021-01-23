    DataTable table1 = ds.Tables["table1"];
    DataTable table2 = ds.Tables["table2"];
    var records = (from t1 in table1.AsEnumerable()
                   join t2 in table2.AsEnumerable() 
                     on t1.Field<int>("Loop_id") equals t2.Field<int>("Loop_id") 
                   select new {T1_Column1 = t1.Field<string>("Column1"),
                               T2_Column2 = t2.Field<string>("Column2"),
                               T2_Column1 = t2.Field<string>("Column1")});
