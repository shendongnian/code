    List<string> customKeys = dbContext.Custom_SegmentsParseds.Select(s => s.InteractionIDKey).ToList();
    List<string> interactionKeys = dbContext.InteractionSegmentDetails.Select(s => s.InteractionIDKey).ToList();
    IEnumerable<string> overLap = interactionKeys.Except(customKeys);
    List<InteractionSegmentDetail> detailList = dbContext.InteractionSegmentDetails.Where(seg => overLap.Contains(seg.InteractionIDKey)).ToList();
    
