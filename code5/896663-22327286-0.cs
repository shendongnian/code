    using (var db = new GibFrontierEntities())
    {
        var images = db.CCTV_IMAGES;
        var result = images
            .SelectMany(i => images,
                (first, second) => new { First = first, Second = second })
            .Where(i => i.First != i.Second)
            .Where(i => Math.Abs(
                EntityFunctions.DiffMinutes(i.First.ImageDate, i.Second.ImageDate)) <= 30)
            .Select(i => i.First)
            .Distinct()
            .OrderByDescending(i => i.ImageDate)
            .Take(rows)
            .ToList();
        return result;
    }
