    var query = DbConfig.Tables["table1"].AsEnumerable()
                .Join
                (
                    DbConfig.Tables["table2"].AsEnumerable(),
                    x=>x.Field<string>("item1"),
                    x=>x.Field<string>("itemB"),
                    (t1,t2)=>new {t1,t2}
                )
                .Where
                (
                    x=>x.t2.Field<string>("itemA") == name
                )
                .Select
                (
                    x=>
                    new
                    {
                        x.t1.Field<string>("item"), 
                        x.t1.Field<string>("item2"), 
                        x.t2.Field<string>("itemA"), 
                        x.t2.Field<string>("itemB")
                    }
                )
