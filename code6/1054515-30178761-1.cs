    public int GetRewritten(DateTime startDate, DateTime endDate, List<int> userIds)
    {
        DateTime dt = DateTime.UtcNow;
        var query = new Expression<Func<ContactFeedback, bool>>(c => c.FeedbackDate >= startDate && c.FeedbackDate <= endDate && userIds.Contains(c.UserId) &&
                     (c.Type == FeedbackType.A || c.Type == FeedbackType.B ||
                      c.Type == FeedbackType.C));
        var ret = GetTotalLeadsByFeedback(query);
        Console.WriteLine(string.Format("{0}",DateTime.UtcNow - dt));
        return ret;
    }
    
    private int GetTotalLeadsByFeedback(Expression<Func<ContactFeedback, bool>> predicate)
    {
        return DbContext.ContactFeedback
            .Where(predicate)
            .GroupBy(x => new { TruncateTime = DbFunctions.TruncateTime(x.FeedbackDate), x.LeadId, x.UserId })
            .Count();
    }
