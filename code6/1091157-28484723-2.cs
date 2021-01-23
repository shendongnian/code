    IQueryable<EntityBandA> queryBandA = entitiesB.GroupJoin(entitiesA, entityB => entityB.EntityAID, entityA => entityA.ID, (entityB, entityA) => new { entityB, entityA = entityA.SingleOrDefault() })
                                                  .Select(entity => 
                                                     new EntityBandA 
                                                     { 
                                                        EntityB = entity.entityB, 
                                                        EntityA = entity.entityA
                                                     }
                                                   );
    List<EntityC> entitiesC1 = MapEntityC(queryBandA).ToList();
                                                
