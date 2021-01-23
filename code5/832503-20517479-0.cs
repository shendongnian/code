    var country = context.Countries.First();
    ControlPolicy cp1 = new ControlPolicy()
                {
                    Country = country,
                    ControlPolicyLevelType = 2, 
                    MemberState = country.IsMemberState,
                    OperaModuleType = 2,
                    MemberStateIncluded = true,
                    CreateDate = DateTime.Now,
                    CreatedByUserId = 1,
                };
                context.ControlPolicies.AddObject(cp1);
    
                context.SaveChanges();
