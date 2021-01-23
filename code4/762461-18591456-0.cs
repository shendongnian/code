    using (var context = new WdmEntities())
                    {
                        //get object models from context
                        var objContext = ((IObjectContextAdapter)context).ObjectContext;
                        var items = objContext.MetadataWorkspace.GetItems<EntityContainer>(DataSpace.SSpace);
                        var container = items != null ? items.First() : null;
                        var schemas = new List<string>();
                        if(container != null)
                            schemas = container.BaseEntitySets.Select(set => set.Name).ToList();
                    }
