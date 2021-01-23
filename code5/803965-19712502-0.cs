    var ret = 
        (from taRec in TableA.GetAll()
        join tc1 in TableC.GetAll on taRec.FK_PersonA equals tc1.Id
          into tcRecs1
        from tcRec1 in tcRecs1.DefaultIfEmpty()
        join tc2 in TableC.GetAll on taRec.FK_PersonB equals tc2.Id
          into tcRecs2
        from tcRec2 in tcRecs2.DefaultIfEmpty()
        select new {
            taRec.Id, APerson = tcRec1.FullName, BPerson = tcRec2.FullName
        }).Union(
            from tbRec in TableB.GetAll()
            select new {
                tbRec.Id, APerson = tbRec.FullName, BPerson = tbRec.FullName
        });
 
