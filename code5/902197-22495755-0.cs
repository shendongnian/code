    var query = _context.OTMLessons.Where(l => !l.Hidden);
    
    if (status != null)
        switch (status) {
            case "A":
                // only records that are current (last day plus important states)
                var showIfAfter = DateTime.Now.AddDays(-1);
                query = query.Where(l => l.Date > showIfAfter).Include("Years").Include("Giver");
                break;
            case "ND":
                // only records which aren't deleted
                query = query.Where(l => !l.Status.Equals("Deleted")).Include("Years").Include("Giver");
                break;
            default:
                // records of a specific state
                query = query.Where(l => l.Status.Equals(status)).Include("Years").Include("Giver");
                break;
        }
