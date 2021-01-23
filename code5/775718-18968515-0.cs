    var q = 
      from mt in db.MasterTable
      join ct in db.ChildTable on mt.ID equals ct.MasterID
      where
        ct.ColumnB = 1 &&
        ...
      group new { ct, mt } by new { ct.ColumnA } into g
      select
        new
        {
          g.Key.ColumnA,
          ResultCol = g.Min(x => myConstant + x.mt.ColA > x.mt.ColB
    								? myConstant + x.mt.ColA
    								: x.mt.ColB)
        };
