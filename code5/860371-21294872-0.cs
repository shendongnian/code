    Assembly assembly = Assembly.GetExecutingAssembly();
    var exports = 
    assembly.GetExportedTypes()
            .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                                    .Select(member => new
                                    {
                                        type.FullName,
                                        Member = member.ToString()
                                    }))
            .ToList();
