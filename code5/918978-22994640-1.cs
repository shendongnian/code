    var enumerableDT= test.AsEnumerable();
    var classesWithHTMLCount = enumerableDT.Count(x => x["Classes"].ToString()
                                                                   .Contains("/>"));
    var studiosWithHTMLCount = enumerableDT.Where(x => x["Classes"].ToString()
                                                                   .Contains("/>"))
                                           .GroupBy(x => x["Studio"])
                                           .Count();
