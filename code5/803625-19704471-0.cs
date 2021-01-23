    IEnumerable<SomeObject> validHighestHeights = objects
                .Where(o => o.IsValid)
                .GroupBy(o => o.Height)
                .OrderByDescending(g => g.Key)
                .First();
