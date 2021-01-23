    // referencing
    //    System.Data.DataSetExtensions
    //    System.Linq.Parallel
    dt.AsEnumerable().AsParalell()
        .Where(row => !(row["~fldDateCreated"] is DBNull))
        .ForAll(row =>
        {
            row.SetField(
                "fldDateCreated",
                new TypedDateTime((DateTime)row["~fldDateCreated"]));
        });
