    var query = from u in context.Jobs
                join q in context.Quotations on u.QuotationId equals q.QuotationId
                join c in context.Customers on q.CustomerId equals c.CustomerId
                where u.JobNo == JobNo
                select new { u.JobNo, u.Vessel };
    return query.AsEnumerable() // moves further processing to memory
                .Select(x => new List<ProcurementDisplayData> {
                                  new { Key = "a", Value = x.JobNo },
                                  new { Key = "b", Value = x.Vessel }
                               }).ToList();
