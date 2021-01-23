    var bKeyCols = B.AsEnumerable()
        .Select(r => new { col1 = r.Field<string>(1), col2 = r.Field<string>(2) });
    var aKeyCols = A.AsEnumerable()
        .Select(r => new { col1 = r.Field<string>(2), col2 = r.Field<string>(3) });
    var bNotInA = bKeyCols.Except(aKeyCols);
    var bRowsNotInA = from row in B.AsEnumerable()
                      join keyCols in bNotInA
                      on new { col1 = row.Field<string>(1), col2 = row.Field<string>(2) } equals keyCols
                      select row;
