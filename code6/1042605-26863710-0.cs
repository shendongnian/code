    public List<AllMarks> RIMarks(string filter)
    {
    if (filter == "Student") {
     var MarkTable = from p in MainDB.classTable
                            group p by new { p.Student} into g
                            select new AllMarks
                                 {
                                     Column = g.Key.fil,
                                     Marks = g.Sum(f => f.Mark)
                                 };
        }
     else if (filter == "Teacher") {
       var MarkTable = from p in MainDB.classTable
                            group p by new { p.Teacher} into g
                            select new AllMarks
                                 {
                                     Column = g.Key.fil,
                                     Marks = g.Sum(f => f.Mark)
                                 };
    }
     else if (filter == "Subject") {
        var MarkTable = from p in MainDB.classTable
                            group p by new { p.Subject} into g
                            select new AllMarks
                                 {
                                     Column = g.Key.fil,
                                     Marks = g.Sum(f => f.Mark)
                                 };
    }
	}
