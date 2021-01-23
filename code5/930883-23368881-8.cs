    int[] resources = (from a in context.Beamline_Requests
                       join b in context.Technique_Requests on a.Technique_Request_ID equals b.ID
                       where b.Beamtime_Request_ID == id
                       select new 
                       { 
                           Beamline_ID = a.Beamline_ID,
                           ID = b.ID
                       })
                       .OrderBy(a => a.ID)
                       .Select(r=> r.Beamline_ID)
                       .Distinct()
                       .ToArray();
