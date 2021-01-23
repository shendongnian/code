    GroupNamesWithCorrespondingEffects = (from g in db.Groups
                                 select new GroupNameWithCorrespondingEffect
                                 {
                                    GroupName = g.GroupName,
                                    CorrespondingEffect = g.Master_Effects.Effect,
                                    ParentID = g.ParentId
                                 }).ToList();
