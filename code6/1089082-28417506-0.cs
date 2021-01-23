    public static class ReportListExtensions
    {
        public static Report GetReport(this IEnumerable<Report> reports, DateTime date)
        {
            return new Report
            {
                AnnouncementDate = date,
                ValueAnnounced = reports.OrderByDescending(r => r.AnnouncementDate)
                                        .First(r => r.AnnouncementDate < date)
                                        .ValueAnnounced
            };
        }
    }
