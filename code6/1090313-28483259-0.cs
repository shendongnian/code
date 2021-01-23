    public void read()
            {
                using (var db = new PortalContext())
                {
                    var objectContext = ((IObjectContextAdapter)db).ObjectContext;
                    var container = objectContext.MetadataWorkspace.GetEntityContainer(objectContext.DefaultContainerName, DataSpace.CSpace);
                    int maxLength = (int)container.EntitySets["Customers"].ElementType.Properties["LastName"].MaxLength;
                }
            }
