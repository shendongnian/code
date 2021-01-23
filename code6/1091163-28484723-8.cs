    IQueryable<EntityBandA> queryBandA = entitiesB.GroupJoin(entitiesA, entityB => entityB.EntityAID, entityA => entityA.ID, 
                                                     (entityB, entityA) => new EntityBandA 
                                                     { 
                                                        EntityB = entityB, 
                                                        EntityA = entityA.SingleOrDefault()
                                                     });
    List<EntityC> entitiesC1 = MapEntityC(queryBandA).ToList();
                                                
