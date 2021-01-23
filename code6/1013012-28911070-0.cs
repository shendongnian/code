    public static void UpdateSegment(ISegment data)
    {
        if (data == null) throw new ArgumentNullException("The expected Segment data is not here.");
        var context = GetContext();
        var originalData = context.Segments.SingleOrDefault(i => i.SegmentId == data.SegmentId);
        if (originalData == null) throw new NullReferenceException("The expected original Segment data is not here.");
        FrameworkTypeUtility.SetProperties(data, originalData);
        context.SaveChanges();
    }
