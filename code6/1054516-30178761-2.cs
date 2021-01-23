    public int GetNotOriginal(DateTime startDate, DateTime endDate, List<int> userIds)
    {
        DateTime dt = DateTime.UtcNow;
        var ret = DbContext.ContactFeedback
               .AsEnumerable()
               .Where(c => c.FeedbackDate >= startDate && 
                c.FeedbackDate <= endDate && userIds.Contains(c.UserId) &&
                (c.Type == FeedbackType.A || c.Type == FeedbackType.B || c.Type == FeedbackType.C))
                .GroupBy(x => new {TruncateTime = DbFunctions.TruncateTime(x.FeedbackDate), x.LeadId, x.UserId})
                .Count();
        Console.WriteLine(string.Format("{0}",DateTime.UtcNow - dt));
        return ret;
    }
