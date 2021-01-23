    var pack = new ConventionPack();
    pack.Add(new CamelCaseElementNameConvention());
    ConventionRegistry.Register("camel case",
                                pack,
                                t => t.FullName.StartsWith("Your.Name.Space."));
