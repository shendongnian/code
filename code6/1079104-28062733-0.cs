    var query = Context.MyTable.Where(table => table.Col < 4);
    if (someConditionThatCannotBeEvalutedInLinqToSql) 
    {
       query = query.Where(tabl => table.Col2 == 5);
    }
