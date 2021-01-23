    IDictionary<string, ICollection<EdmMember>> dict = // create instance ...    
    MetadataWorkspace.GetItems<EntityContainer>(DataSpace.CSpace)
                                 .First()
                                 .BaseEntitySets
                                 .ToList()
                                 .ForEach(s => dict.Add(s.ElementType.Name, s.ElementType.KeyMembers));
