    var query = context.ProcessStepTables
                .Where(s=>s.DiagramID == diagramInfo.DiagramID)
                .OrderBy(s=>s.ProcessNo)
                .ToList() //this will cause the query to be executed on the db
                 //Now perform the selection on returned result set, now the linq
                 //has to do with this dataset
                .Select(s=>new
                 {
                       DiagramProcessID = s.DiagramProcessID,
                       ProcessNo = s.ProcessNo,
                       ProcessID = s.ProcessID,
                       //other items in your custom list
                 });
