    protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                var entityMethod = typeof(DbModelBuilder).GetMethod("Entity");
                foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    var entityTypes = from t in Assembly.GetExecutingAssembly().GetTypes()
                                      where t.GetInterfaces().Contains(typeof(IBaseEnt))
                                               && t.GetConstructor(Type.EmptyTypes) != null
                                      select t;
    
                    foreach (var type in entityTypes)
                    {
                        entityMethod.MakeGenericMethod(type)
                          .Invoke(modelBuilder, null);
                    }
                }
                base.OnModelCreating(modelBuilder);
            }
