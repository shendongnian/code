    _Return.PendingGRemsResultRecord = 
         Context.Where(a => a.Status == 0)
                .Select(a => new {
                   a.GRemGUID.GUID, 
                   CreatorType = a.s.GRemGUID.CreatorType.Value })
                .Distinct()
                .Select(x => new PendingGRemsResultRecord {
                      GUID = x.GUID,
                      Count = App.GroupedRemittance
                                 .GetByFilter(gr => gr.GRemGUID.GUID == x.GUID)
                                 .Count(),
                      CreatorType = x.CreatorType
                  }).ToList();
