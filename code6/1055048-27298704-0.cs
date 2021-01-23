    public static class QueryExtensions
    {
        public static IQueryable<Report> GetByStatus(
        this IQueryable<Report> query, string statusCode)
        {
            if (statusCode == "")
            {
                return query.Where(r => r.ReportStatus.Count == 0); // new reports, no status history
            }
            else
                return query.Where(r => r.ReportStatus.OrderByDescending(s =>
                       s.ReportStatusDate).FirstOrDefault().StatusCode.StatusCode1 == statusCode);
        }
    }
