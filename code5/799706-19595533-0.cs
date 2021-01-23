    var attributeSymbol = compilation.GetTypeByMetadataName("ConsoleApplication1.OneToOneAttribute");
    var classSymbol = compilation.GetTypeByMetadataName("ConsoleApplication1.Program")
                      .GetMembers()
                      .Where(m => 
                          m.Kind == SymbolKind.Property && 
                          m.Attributes.Any(a => a.Equals(attributeSymbol));
