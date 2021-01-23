    // referencing
    //    System.Data.DataSetExtensions
    //    System.Linq.Parallel
    dt.AsEnumerable().AsParalell().ForAll(row => {
            if (!(row["~fldDateCreated"] is DBNull))
            {
                 row["fldDateCreated"] =
                    new TypedDateTime((DateTime)row["~fldDateCreated"]);
            }
        });
