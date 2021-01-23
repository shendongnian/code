            public List<string> EntityNames()
            {
                ObjectContext objContext = ((IObjectContextAdapter)myDbContext).ObjectContext;
                MetadataWorkspace workspace = objContext.MetadataWorkspace;
                IEnumerable<EntityType> tables = workspace.GetItems<EntityType>(DataSpace.SSpace);
                List<string> lst = new List<string>();
                foreach (var table in tables)
                {
                    var entityName = table.FullName.Replace("CodeFirstDatabaseSchema.", "");
                    lst.Add($"{entityName}");
                }
                return lst;
            }
