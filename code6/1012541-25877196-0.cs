    var shortfilenames = new List<string>(){"Avinash_Create.sql" , "Avinash_Insert.sql" , "Avinash_Update.sql" , "Avinash_Delete.sql"};
    var userGroups = shortfilenames
        .Select(fn =>
        {
            string fileName = Path.GetFileNameWithoutExtension(fn);
            string[] nameAndAction = fileName.Split('_');
            return new
            {
                extension = Path.GetExtension(fn),
                fileName,
                name = nameAndAction[0],
                action = nameAndAction[1]
            };
        })
        .GroupBy(x => x.name)
        .Select(g => g.OrderByDescending(x => x.action.Equals("CREATE", StringComparison.InvariantCultureIgnoreCase))
                      .ThenByDescending(x => x.action.Equals("INSERT", StringComparison.InvariantCultureIgnoreCase))
                      .ThenByDescending(x => x.action.Equals("UPDATE", StringComparison.InvariantCultureIgnoreCase))
                      .ThenByDescending(x => x.action.Equals("DELETE", StringComparison.InvariantCultureIgnoreCase))
                      .ToList());
    foreach (var ug in userGroups)
    foreach (var x in ug)
        Console.WriteLine("{0} {1}", x.name, x.action);
