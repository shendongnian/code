    foreach (var entity in typeMapper.GetItemsToGenerate<EntityType>(itemCollection))
    {
        fileManager.StartNewFile(entity.Name + ".cs");
        BeginNamespace(code);
    #>
    // <Summary>
    //    My Comments for <#=entity.Name #>
    // </Summary>
    //--
    <#=codeStringGenerator.UsingDirectives(inHeader: false)#>
    <#=codeStringGenerator.EntityClassOpening(entity)#>
    {
    <#
        
