            query = query.OrderBy(x => x.Location.ID).ThenBy(x => x.HolterTestType);
            var htList = query.ToList();
            // now Group by Location. 
            var reportContents = htList.GroupBy(x => x.Location.ID);
            foreach (var r in reportContents)
            {
                //Group by TestType, to get counts.
                var t = r.GroupBy(x => x.HolterTestType);
                var tList = t.ToList();
                
                foreach(var u in tList)
                {
                    var cc = new CompletedCount();
                    var loc = LocationDao.FindById(r.Key);
                    cc.Description = loc.Description;
                    cc.RegionId = loc.Region.ID;
                    cc.DivisionId = loc.Region.Division.ID;
                    cc.TestTypeId = u.Key;
                    cc.Count = u.Count();
                    ccRpt.CompletedCounts.Add(cc);
                }
            }
