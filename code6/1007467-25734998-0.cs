    var attachedEntity = this.context.Entry(orignalEntity);
                        attachedEntity.CurrentValues.SetValues(updatedEntity);
    
        List<string> excludeProperties = new List<string>();
        
                            // Some of these fields you cannot just modify at all.
                            excludeProperties.Add("UniqueIdentifier");
                            excludeProperties.Add("AuthorID");
                            excludeProperties.Add("DateCreated");
                            // You could even ask your dervived calls to tell which one to exclude 
    // excludeProperties.AddRange(this.ExcludeUpdateProperties());
        
                            foreach (var name in excludeProperties)
                            {
                                var property = attachedEntity.Property(name);
                                if (property != null)
                                {
                                    attachedEntity.Property(name).IsModified = false;
                                }
                            }
