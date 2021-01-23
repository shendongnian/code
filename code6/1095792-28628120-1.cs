    // Sample items (some complex objects for example).
    var items = new[] { 1, -3, 6, 5, -2, 0, 3, 4, 8, 0, 4, 7, 2, 9, -3 }
        .Select(
            i => new {
                Name = string.Format("Item {0}", i), 
                Value = i                        
            }
        ).ToArray();
    // Get enumerator of segment max for Value field.
    var segMaxEnumerator = items.LeftSegAggregate(
        // Aggregation function (returns max value from segment of items).
        seg => seg.Select(i => i.Value).Max(),
        // Size of target segment.
        10  
    ).GetEnumerator();
    // Here is your loop:
    for (var i = 0; i < items.Length; i++)
    {                
        // Move segment max enumerator to next item.
        segMaxEnumerator.MoveNext();
        // Use segMaxEnumerator.Current to take segment max.
        Console.WriteLine("{0}: {1}", i, segMaxEnumerator.Current);
    }
