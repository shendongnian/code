    foreach (var entity in typeMapper.GetItemsToGenerate<EntityType>(itemCollection))
    {
        fileManager.StartNewFile(entity.Name + ".cs");
        BeginNamespace(code);
    #>
    <#=codeStringGenerator.UsingDirectives(inHeader: false)#>
    <#=codeStringGenerator.EntityClassOpening(entity)#>
    {
    <#
        var propertiesWithDefaultValues = typeMapper.GetPropertiesWithDefaultValues(entity);
        var collectionNavigationProperties = typeMapper.GetCollectionNavigationProperties(entity);
        var complexProperties = typeMapper.GetComplexProperties(entity);
        if (propertiesWithDefaultValues.Any() || collectionNavigationProperties.Any() || complexProperties.Any())
        {
    #>
        public <#=code.Escape(entity)#>()
        {
    <#
