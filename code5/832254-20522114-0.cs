    var scripter = new Scripter(server)
    {
        Options = new ScriptingOptions()
        {
            IncludeIfNotExists = true,
            IncludeDatabaseRoleMemberships = true,
            
            //ADDED THIS OPTION
            FileName = Path.Combine(path, "Script.sql"),
            // lots of other options here
        }
    };
    foreach (User smoObject in database.Users)
    {
        var sc = scripter.Script(new Urn[] { smoObject.Urn });
        // no need to write to file anymore since scripter automatically does it
    }
