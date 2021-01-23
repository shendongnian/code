    IEnumerable<Audit> audits = ...
    
    var longestAuditsByUser = audits.OrderBy(a => a.Timestamp)
        // group by user, since presumably we don't want to match an open from one user with a close from another
        .GroupBy(a => a.User)
        .Select(userAudits => 
        {
            // first, align each audit entry with it's index within the entries for the user
            var indexedAudits = userAudits.Select((audit, index) => new { audit, index });
            // create separate sequences for open and close/ack entries
            var starts = indexedAudits.Where(t => t.audit.AuditType == "Open");
            var ends = indexedAudits.Where(t => t.audit.AuditType == "Close" || t.audit.AuditType == "Acknowledge");
            
            // find the "transactions" by joining starts to ends where start.index = end.index - 1
            var pairings = starts.Join(ends, s => s.index, e => e.index - 1, (start, end) => new { start, end });
            // find the longest such pairing with Max(). This will throw if no pairings were
            // found. If that can happen, consider changing this Select() to SelectMany()
            // and returning pairings.OrderByDescending(time).Take(1)
            var longestPairingTime = pairings.Max(t => t.end.Timestamp - t.start.Timestamp);
            return new { user = userAudits.Key, time = longestPairingTime };
        });
    
    // now that we've found the longest time for each user, we can easily find the longest
    // overall time as well
    var longestOverall = longestAuditsByUser.Max(t => t.time);
