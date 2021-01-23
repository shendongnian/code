    public static void Main()
    {
        var context = new testCollection();
        var id = 45;
        // Short example...
        var rows = (context.items.Where(data => data.ItemId.Equals(id))
                .Select(selData => new
                {
                    ItemNumber = selData.ItemNumber,
                    ItemDescription = selData.ItemDescription,
                    UnitDescription = selData.UnitDescription
                }
                        ));
        // Here you still have access to data and the types of the data.
        foreach (var row in row)
        {
            // do something with the data....
            var someint = o.ItemNumber;
            var someString = o.ItemDescription;
            var someotherstring = o.ItemDescription;
        }
    }
