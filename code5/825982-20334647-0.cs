    projectList = from MilestoneTypeTable in db.tblMilestoneTypes
                          join MilestoneTable in db.tblMilestones on MilestoneTypeTable.MilestoneID equals MilestoneTable.MilestoneTypeID into MileStones 
    from mileStone in MileStones 
    join from projects in db.tblProjects
    on mileStone.RevID  equals projects.RevID
    select new { MileStoneType = MilestoneTypeTable, MileStones = mileStone , Project = projects };
