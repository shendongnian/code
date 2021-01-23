        int sum = 0;
        // items
        foreach (var item in items)
        {
            // .SelectMany(i => i.Children)
            foreach (var child in item.Children)
            {
                // .Sum(i => i.Age)
                sum += child.Age;
            }
        }
        // result is in sum
