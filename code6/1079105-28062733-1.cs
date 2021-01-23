    var query = Context.MyTable.Where(tbl => tbl.Col > 4);
    if (someConditionThatCannotBeEvalutedInLinqToSql)
    {
       query = query.Where(2)tabl => table.Col2 == 5);
    }
