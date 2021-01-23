    static void Main(string[] args)
    {
        string sql = @"
    /* 
    GO
    */ 
    SELECT * FROM [table]
    GO
    
    SELECT * FROM [table]
    SELECT * FROM [table]
    
    GO
    
    SELECT * FROM [table]";
        string[] errors;
        var scriptFragment = Parse(sql, SqlVersion.Sql100, true, out errors);
        if (errors != null)
        {
            foreach (string error in errors)
            {
                Console.WriteLine(error);
                return;
            }
        }
        TSqlScript tsqlScriptFragment = scriptFragment as TSqlScript;
        if (tsqlScriptFragment == null)
            return;
        var options = new SqlScriptGeneratorOptions { SqlVersion = SqlVersion.Sql100, KeywordCasing = KeywordCasing.PascalCase };
        foreach (TSqlBatch batch in tsqlScriptFragment.Batches)
        {
            Console.WriteLine("--");
            string batchText = ToScript(batch, options);
            Console.WriteLine(batchText);                
        }
    }
    public static TSqlParser GetParser(SqlVersion level, bool quotedIdentifiers)
    {
        switch (level)
        {
            case SqlVersion.Sql80:
                return new TSql100Parser(quotedIdentifiers);
            case SqlVersion.Sql90:
                return new TSql90Parser(quotedIdentifiers);
            case SqlVersion.Sql100:
                return new TSql80Parser(quotedIdentifiers);
            case SqlVersion.SqlAzure:
                return new TSqlAzureParser(quotedIdentifiers);
            default:
                throw new ArgumentOutOfRangeException("level");
        }
    }
    public static IScriptFragment Parse(string sql, SqlVersion level, bool quotedIndentifiers, out string[] errors)
    {
        errors = null;
        if (string.IsNullOrWhiteSpace(sql)) return null;
        sql = sql.Trim();
        IScriptFragment scriptFragment;
        IList<ParseError> errorlist;
        using (var sr = new StringReader(sql))
        {
            scriptFragment = GetParser(level, quotedIndentifiers).Parse(sr, out errorlist);
        }
        if (errorlist != null && errorlist.Count > 0)
        {
            errors = errorlist.Select(e => string.Format("Column {0}, Identifier {1}, Line {2}, Offset {3}",
                                                            e.Column, e.Identifier, e.Line, e.Offset) +
                                                Environment.NewLine + e.Message).ToArray();
            return null;
        }
        return scriptFragment;
    }
        
    public static SqlScriptGenerator GetScripter(SqlScriptGeneratorOptions options)
    {
        if (options == null) return null;
        SqlScriptGenerator generator;
        switch (options.SqlVersion)
        {
            case SqlVersion.Sql90:
                generator = new Sql90ScriptGenerator(options);
                break;
            case SqlVersion.Sql80:
                generator = new Sql80ScriptGenerator(options);
                break;
            case SqlVersion.Sql100:
                generator = new Sql100ScriptGenerator(options);
                break;
            case SqlVersion.SqlAzure:
                generator = new SqlAzureScriptGenerator(options);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        return generator;
    }
    public static string ToScript(IScriptFragment scriptFragment, SqlScriptGeneratorOptions options)
    {
        var scripter = GetScripter(options);
        if (scripter == null) return string.Empty;
        string script;
        scripter.GenerateScript(scriptFragment, out script);
        return script;
    }
