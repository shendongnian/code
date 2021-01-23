    var query = listStructures.GroupBy(row => new {row.Code, row.range, row.Unit, row.Type} )
                         .Select(grp => new StructuresDS
                         {
                             Code = grp.Key.Code,
                             Range = grp.Key.Range,
                             Unit = grp.Key.Unit,
                             Type = grp.Key.Type,
                             Volumne = grp.Sum(r=> r.Volume)
                         });
    listMicroSummary = query.ToList();// if you want a List
