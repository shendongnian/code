    ActionCounts = tms.TechnologyAudits.Where(a =>
        (EntityFunctions.TruncateTime(a.DateTimeEnd) == d && a.TechnologyID != null))
        .GroupBy(a => a.AuditAction.Name.ToLower())
        .Select(g => new {
            Action = g.Key
            ItemCount = g.Count(gc => gc.Key == g.Key);
        }).ToList();
    
