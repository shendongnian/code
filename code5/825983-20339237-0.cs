        var query = from ProjectTable in db.tblProjects
                from MilestoneTable in db.tblMilestones.
                     Where(mile => mile.RevID == ProjectTable.RevID && 
                     mile.MilestoneDate == db.tblMilestones.OrderBy(x => x.RevID).
                     Select(x => x.MilestoneDate).Max())
                from GeoCodeTable in db.GEOCODEs.
                     Where(geo => geo.RevID == MilestoneTable.RevID)
                select new
                {
                    Milestone = MilestoneTable,
                    Project = ProjectTable,
                    GeoCode = GeoCodeTable
                };
                
