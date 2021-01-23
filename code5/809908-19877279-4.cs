    public static void Main()
    {
        // Short example...
        var rows = (from t1 in context.InventoryUnit
                    join t2 in context.InventoryItem on t1.UnitId equals t2.UnitId
                    where t2.ItemId == id
                    orderby t2.ItemNumber, t2.ItemDescription
                    select new
                    {
                        ItemNumber = t2.ItemNumber,
                        ItemDescription = t2.ItemDescription,
                        UnitDescription = t1.UnitDescription
                     });
        // Here you still have access to data and the types of the data.
        foreach (var row in row)
        {
            // do something with the data....
            var someint = row.ItemNumber;
            var someString = row.ItemDescription;
            var someotherstring = row.ItemDescription;
        }
    }
