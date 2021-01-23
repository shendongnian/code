    var cSpaceEntities = mw.GetItems(DataSpace.CSpace).OfType<EntityType>();
    
    foreach (var entity in cSpaceEntities) {
         var autoIds = entity.KeyMembers.Where(p => 
                            p.MetadataProperties
                                .Any(m =>    m.PropertyKind == PropertyKind.Extended 
                	                  && Convert.ToString(m.Value) == "Identity")).ToArray();
                }
