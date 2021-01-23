    public List<User> GetLeaderBoard()
    {
    return (from u in myDB.Users
            join tc in myDB.TriviaCodes on u.userID equals tc.userID into gj
            from subtc in gj.DefaultIfEmpty()
            group new { u, subtc } by u into g
            select g)
            .OrderBy(g => g.Sum(p1 => p1.subtc == null ? 0 : p1.subtc.pointsGained))
            .Select(g => g.Key).Take(100).Where(u => u.myPoints > 0).ToList();
    }
