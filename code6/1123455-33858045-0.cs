    class Program
    {
        static void Main(string[] args)
        {
            var text = @" 
    public class MyClass 
    { 
    public void MyMethod() 
    { 
        const int i = 0; // this is ok
        decimal d = 11; // this is not ok
        string s = ""magic"";
        if (i == 29) // another magic
        {
        }
        else if (s != ""again another magic"")
        {
        }
    }
    }";
            ScanHardcodedFromText("test.cs", text, (n, s) =>
            {
                Console.WriteLine(" " + n.SyntaxTree.GetLineSpan(n.FullSpan) + ": " + s);
            }).Wait();
        }
    
        public static async Task ScanHardcodedFromText(string documentName, string text, Action<SyntaxNodeOrToken, string> scannedFunction)
        {
            if (text == null)
                throw new ArgumentNullException("text");
    
            AdhocWorkspace ws = new AdhocWorkspace();
            var project = ws.AddProject(documentName + "Project", LanguageNames.CSharp);
            ws.AddDocument(project.Id, documentName, SourceText.From(text));
            await ScanHardcoded(ws, scannedFunction);
        }
    
        public static async Task ScanHardcodedFromSolution(string solutionFilePath, Action<SyntaxNodeOrToken, string> scannedFunction)
        {
            if (solutionFilePath == null)
                throw new ArgumentNullException("solutionFilePath");
    
            var ws = MSBuildWorkspace.Create();
            await ws.OpenSolutionAsync(solutionFilePath);
            await ScanHardcoded(ws, scannedFunction);
        }
    
        public static async Task ScanHardcodedFromProject(string solutionFilePath, Action<SyntaxNodeOrToken, string> scannedFunction)
        {
            if (solutionFilePath == null)
                throw new ArgumentNullException("solutionFilePath");
    
            var ws = MSBuildWorkspace.Create();
            await ws.OpenProjectAsync(solutionFilePath);
            await ScanHardcoded(ws, scannedFunction);
        }
    
        public static async Task ScanHardcoded(Workspace workspace, Action<SyntaxNodeOrToken, string> scannedFunction)
        {
            if (workspace == null)
                throw new ArgumentNullException("workspace");
    
            if (scannedFunction == null)
                throw new ArgumentNullException("scannedFunction");
    
            foreach (var project in workspace.CurrentSolution.Projects)
            {
                foreach (var document in project.Documents)
                {
                    var tree = await document.GetSyntaxTreeAsync();
                    var root = await tree.GetRootAsync();
                    foreach (var n in root.DescendantNodesAndTokens())
                    {
                        if (!CanBeMagic(n.Kind()))
                            continue;
    
                        if (IsWellKnownConstant(n))
                            continue;
    
                        string suggestion;
                        if (IsMagic(n, out suggestion))
                        {
                            scannedFunction(n, suggestion);
                        }
                    }
                }
            }
        }
    
        public static bool IsMagic(SyntaxNodeOrToken kind, out string suggestion)
        {
            var vdec = kind.Parent.Ancestors().OfType<VariableDeclarationSyntax>().FirstOrDefault();
            if (vdec != null)
            {
                var dec = vdec.Parent as MemberDeclarationSyntax;
                if (dec != null)
                {
                    if (!HasConstOrEquivalent(dec))
                    {
                        suggestion = "member declaration could be const: " + dec.ToFullString();
                        return true;
                    }
                }
                else
                {
                    var ldec = vdec.Parent as LocalDeclarationStatementSyntax;
                    if (ldec != null)
                    {
                        if (!HasConstOrEquivalent(ldec))
                        {
                            suggestion = "local declaration contains at least one non const value: " + ldec.ToFullString();
                            return true;
                        }
                    }
                }
            }
            else
            {
                var expr = kind.Parent.Ancestors().OfType<ExpressionSyntax>().FirstOrDefault();
                if (expr != null)
                {
                    suggestion = "expression uses a non const value: " + expr.ToFullString();
                    return true;
                }
            }
    
            // TODO: add other cases?
    
            suggestion = null;
            return false;
        }
    
        private static bool IsWellKnownConstant(SyntaxNodeOrToken node)
        {
            if (!node.IsToken)
                return false;
    
            string text = node.AsToken().Text;
            if (text == null)
                return false;
    
            // note: this is naïve. we also should add 0d, 0f, 0m, etc.
            if (text == "1" || text == "-1" || text == "0")
                return true;
    
            // ok for '\0' or '\r', etc.
            if (text.Length == 4 && text.StartsWith("'\\") && text.EndsWith("'"))
                return true;
    
            if (text == "' '")
                return true;
    
            // TODO add more of these? or make it configurable...
    
            return false;
        }
    
        private static bool HasConstOrEquivalent(SyntaxNode node)
        {
            bool hasStatic = false;
            bool hasReadOnly = false;
            foreach (var tok in node.ChildTokens())
            {
                switch (tok.Kind())
                {
                    case SyntaxKind.ReadOnlyKeyword:
                        hasReadOnly = true;
                        if (hasStatic)
                            return true;
                        break;
    
                    case SyntaxKind.StaticKeyword:
                        hasStatic = true;
                        if (hasReadOnly)
                            return true;
                        break;
    
                    case SyntaxKind.ConstKeyword:
                        return true;
                }
            }
            return false;
        }
    
        private static bool CanBeMagic(SyntaxKind kind)
        {
            return kind == SyntaxKind.CharacterLiteralToken ||
                kind == SyntaxKind.NumericLiteralToken ||
                kind == SyntaxKind.StringLiteralToken;
        }
    }
