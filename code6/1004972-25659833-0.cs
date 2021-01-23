    // Creating "and" clause
    BooleanQuery booleanQueryInner = new BooleanQuery();
    booleanQueryInner.Add(new TermQuery(new Term("isprivate", "false")), BooleanClause.Occur.MUST);
    booleanQueryInner.Add(new TermQuery(new Term("userid", "1")), BooleanClause.Occur.MUST);
    // Creating "or" clause
    BooleanQuery booleanQueryMain = new BooleanQuery();
    booleanQueryMain.Add(new TermQuery(new Term("isprivate", "true")), BooleanClause.Occur.SHOULD);
    booleanQueryMain.Add(booleanQueryInner, BooleanClause.Occur.SHOULD);
