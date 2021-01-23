    using System.Management.Automation;
    using System.Management.Automation.Language;
    static void Main(string[] args)
    {
        const string testScript = @"
        param(
            [ValidateNotNullOrEmpty()]
            [string]$Name
        )
        get-process $name
    ";
        foreach(var parameter in GetScriptParameters(testScript))
        {
            Console.WriteLine(parameter);
        }
    }
    private static List<string> GetScriptParameters(string script)
    {
        Token[] tokens;
        ParseError[] errors;
        var ast = Parser.ParseInput(script, out tokens, out errors);
        if (errors.Length != 0)
        {
            Console.WriteLine("Errors: {0}", errors.Length);
            foreach (var error in errors)
            {
                Console.WriteLine(error);
            }
            return null;
        }
        return ast.ParamBlock.Parameters.Select(p => p.Name.ToString()).ToList();
    }
