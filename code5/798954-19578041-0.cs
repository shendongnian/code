            using (DBEntities db = new DBEntities())
            {
                GroupsAndEffects = (from g in db.Groups
                              select new GroupAndEffect
                                {
                                 GroupName = g.Name
                                 EffectCorrespondingToGroup = g.Type_Effect.Name
                                }).ToList();
            }
