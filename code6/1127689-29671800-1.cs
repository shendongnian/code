     var tblGlobalLogOnLogOffStudentBans = db.tblGlobalLogOnLogOffStudentBans
        .Include(t => t.tblGlobalLogOnLogOffTime)
        .OrderBy(t => t.StartBan)
        .GroupBy(t => t.UserID)
        .Select(g => g.First())
        .Take(10);
