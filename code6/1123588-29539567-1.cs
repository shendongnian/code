    var pack = new ConventionPack();
    pack.Add(new IgnoreIfNullConvention(true));
    ConventionRegistry.Register("ignore nulls",
                                pack,
                                t => true);
