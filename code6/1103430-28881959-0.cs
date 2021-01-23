    Exam examAlias = null;
    var query = session.QueryOver(() => examAlias);
    //here we will check what needed
    if(newExam.ActiveTo == null)
    {
        query.Where(() => examAlias.ActiveTo == null)
    }
    // we can repeat that many times and build WHERE clause as required
    ...
    // finally the query
    examsInSameTime = query.Future<Exam>();
