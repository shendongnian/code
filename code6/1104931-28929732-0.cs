            public <#=code.Escape(container)#>()
            : base("name=<#=container.Name#>")
        {
        <#
    
        if (!loader.IsLazyLoadingEnabled(container))
        {
        #>
            this.Configuration.LazyLoadingEnabled = false;
        <#
    
        }
    
    foreach (var entitySet in container.BaseEntitySets.OfType<EntitySet>())
    {
        // Note: the DbSet members are defined below such that the getter and
        // setter always have the same accessibility as the DbSet definition
        if (Accessibility.ForReadOnlyProperty(entitySet) != "public")
        {
        #>
                <#=codeStringGenerator.DbSetInitializer(entitySet)#>
        <#
            }
        }
        #>
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    <#
        foreach (var entitySet in container.BaseEntitySets.OfType<EntitySet>())
        {
    #>
        <#=codeStringGenerator.DbSet(entitySet)#>
    <#
        }
    
        foreach (var edmFunction in container.FunctionImports)
        {
            WriteFunctionImport(typeMapper, codeStringGenerator, edmFunction, modelNamespace, includeMergeOption: false);
        }
    #>
