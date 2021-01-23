    var travelReports = db.TravelReports.Include("ApprovalStatuses")
                    .Select(s => new {Query = s, Status = s.Status}) //Project to a new object that has the status pre-calculated
                    .Where(s => s.Status == TravelReportStatus.PendingApproval || s.Status == TravelReportStatus.Processed || s.Status == TravelReportStatus.Denied)
                    .Select(s => s.Query) //flatten the object back out.
                    .Where(s => s.IsDeleted == false)
                    .ToList();
