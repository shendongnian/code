    Table table = GetTable();
    List<string> scripts = table.Script(new ScriptingOptions
    {
        DriAll = true,
        FullTextCatalogs = true,
        FullTextIndexes = true,
        Indexes = true,
        SchemaQualify = true
    }).Cast<string>().ToList();
    // There is a bug in the SQL SMO libraries that changes the scripting of the
    // default constraints depending on whether or not the table has any rows.
    // This hack gets around the issue by modifying the scripts to always include
    // the constaints in the CREATE TABLE definition. 
    // https://connect.microsoft.com/SQLServer/Feedback/Details/895113
    //
    // First, get the CREATE TABLE script to modify.
    string originalCreateTableScript = scripts.Single(s => s.StartsWith("CREATE TABLE"));
    string modifiedCreateTableScript = originalCreateTableScript;
    bool modificationsMade = false;
    // This pattern will match all ALTER TABLE scripts that define a default constraint.
    Regex defineDefaultConstraintPattern = new Regex(@"^ALTER TABLE .+ ADD\s+CONSTRAINT \[(?<constraint_name>[^\]]+)]  DEFAULT (?<constraint_def>.+) FOR \[(?<column>.+)]$");
    // Find all the matching scripts.
    foreach (string script in scripts)
    {
        Match defaultConstraintMatch = defineDefaultConstraintPattern.Match(script);
        if (defaultConstraintMatch.Success)
        {
            // We have found a default constraint script. The following pattern
            // will match the line in the CREATE TABLE script that defines the
            // column on which the constraint is defined.
            Regex columnPattern = new Regex(@"^(?<def1>\s*\[" + Regex.Escape(defaultConstraintMatch.Groups["column"].Value) + @"].+?)(?<def2>,?\r)$", RegexOptions.Multiline);
            // Replace the column definition with a definition that includes the constraint.
            modifiedCreateTableScript = columnPattern.Replace(modifiedCreateTableScript, delegate (Match columnMatch)
            {
                modificationsMade = true;
                return string.Format(
                    "{0} CONSTRAINT [{1}]  DEFAULT {2}{3}",
                    columnMatch.Groups["def1"].Value,
                    defaultConstraintMatch.Groups["constraint_name"].Value,
                    defaultConstraintMatch.Groups["constraint_def"].Value,
                    columnMatch.Groups["def2"].Value);
            });
        }
    }
    if (modificationsMade)
    {
        int ix = scripts.IndexOf(originalCreateTableScript);
        scripts[ix] = modifiedCreateTableScript;
        scripts.RemoveAll(s => defineDefaultConstraintPattern.IsMatch(s));
    }
