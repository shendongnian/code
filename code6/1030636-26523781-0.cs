    public List<User> GetLeaderBoard()
       {
           SuperGoalDataClassesDataContext myDB = new SuperGoalDataClassesDataContext();
           return myDB.Users.Where(u=> u.firstName != null && u.lastName != null).AsEnumerable()
                             .OrderBy(u=> FillUserCodes(u).Sum(co => co.pointsGained ?? 0))
                             .Take(100).Where(u=> u.mypoints > 0).ToList();
       }
