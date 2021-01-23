    var result = (from pi in projectInfo
                  join pu in projectupdates
                  on pi.ProjectID equals pu.ProjectID into g
                  let data = g.OrderByDescending(x => DateTime.ParseExact(x.CreateDate, 
                               "dd/M/yyyy", CultureInfo.InvariantCulture)).FirstOrDefault()
                  select new
                  {
                      ProjectID = data.ProjectID,
                      CreatedDate = data.CreateDate,
                      DataA = pi.DataA,
                      DataB = data.DataB
                   }).ToList();
