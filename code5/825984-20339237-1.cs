        var query = from ProjectTable in db.tblProjects
                            from GeoCodeTable in db.GEOCODEs.Where(geo => geo.RevID == ProjectTable.RevID).DefaultIfEmpty()
                            from MilestoneTable in db.tblMilestones.Where(mile => mile.RevID == GeoCodeTable.RevID && mile.MilestoneDate == db.tblMilestones.OrderBy(x => x.RevID).Select(x => x.MilestoneDate).Max()).DefaultIfEmpty()
                            from MilestomeTypeTable in db.tblMilestoneTypes.Where(mt => mt.MilestoneID == MilestoneTable.MilestoneTypeID).DefaultIfEmpty()
                select new
                {
                    Milestone = MilestoneTable,
                    Project = ProjectTable,
                    GeoCode = GeoCodeTable
                };
                
