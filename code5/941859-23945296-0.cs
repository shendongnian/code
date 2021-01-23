    public List<EmployeeGoal> GetEmpGoalList(int empID)
    {
        //Get employee info
        var empInfo = db.Employees.Where(x => x.ID == empID).Select(x => new { ID = x.ID, LastName = x.LastName, Firstname = x.FirstName }).FirstOrDefault();
        //Get initial bottom tier list of employee goals
        List<int> goalIdList = db.EmployeeMaps.Where(x => x.EmployeeID == empID).Select(x => x.GoalID).ToList();
        List<EmployeeGoal> empGoalList = new List<EmployeeGoal>();
        List<int> usedGoalList = new List<int>();
        foreach (var goal in goalIdList)
        {
            var tempID = goal;
            while (tempID != 0 && tempID != null)
            {
                var gmData = (from g in db.Goals
                          join m in db.EmployeeMaps.Where(m => m.EmployeeID == empInfo.ID) on g.ID equals m.GoalID into m_g
                          from mg in m_g.DefaultIfEmpty()
                          where g.Goals == tempID
                          select new EmployeeGoal
                          {
                              EmployeeID = empInfo.ID,
                              LastName = empInfo.LastName,
                              FirstName = empInfo.FirstName,
                              GoalID = g.ID,
                              Name = g.Name,
                              ParentID = g.ParentID,
                              Parent = g.Parent,
                              WeightPct = (mg == null) ? 0 : mg.WeightPct,
                              Locked = (mg == null) ? 0 : mg.State.Equals(1),
                              Activities = g.Activities
                          }).FirstOrDefault();
                if (!usedGoalList.Contains(gmData.GoalID))
                {
                    empGoalList.Add(gmData);
                    UsedGoalList.Add(gmData.GoalID);
                }
                tempID = gmData.ParentId;
            }
        }
        return empGoalList;
    }
