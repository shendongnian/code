    var visitorIdList = new byte[][]
        {
            new byte[] { 2, 2 },
            new byte[] { 4, 4 },
        }.ToList();
    var visitors = context.Visitors
        .Where(v => visitorIdList.Contains(v.VisitorId))
        .ToList();
