    var attributeSymbol = compilation.GetTypeByMetadataName("ConsoleApplication1.OneToOneAttribute");
    var classSymbol = compilation.GetTypeByMetadataName("ConsoleApplication1.Program")
                      .GetMembers()
                      .Where(m => 
                          m.Kind == CommonSymbolKind.Property && 
                          m.GetAttributes().Any(a => a.AttributeClass.MetadataName == attributeSymbol.MetadataName));
