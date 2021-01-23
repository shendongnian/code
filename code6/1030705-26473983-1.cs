    public List<User> GetLeaderBoard()
    {
    return (from u in myDB.Users
           select new {
                       User = u,
                       Sum = (from tc in myDB.TriviaCodes 
                              where tc.userID == u.userID 
                              select c).Sum(p => p == null ? 0 : p.pointsGained)
                      })
    .OrderBy(g => g.Sum)
    .Select(g => g.User)
    .Take(100)
    .Where(u => u.myPoints > 0)
    .ToList();
    }
