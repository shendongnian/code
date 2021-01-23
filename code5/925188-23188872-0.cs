    var json = from r in results
                       select Convert(new
                       {
                           r.CaseId,
                           r.TamisCaseNo,
                           r.TaxPdr,
                           r.OarNo,
                           r.Tin,
                           DateReceived = r.DateReceived.ToShortDateString(),
                           r.IdrsOrgAssigned,
                           r.IdrsTeAssigned,
                           r.DateRequestComp
                       });
