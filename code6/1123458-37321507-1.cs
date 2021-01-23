    /// <summary>
    /// Scans all cs files in the solutions for magic strings and numbers using the Roslyn 
    /// compiler and analyzer tools.
    /// Based upon a Roslyn code sample.
    /// </summary>
    class MagicStringAnalyzer
    {
        protected static Filter filter;
        static void Main(string[] args)
        {
            string outputPath = @"E:\output.txt";
            string solutionPath = @"E:\Solution.sln";
            filter = new Filter(@"E:\IgnorePatterns.txt");
            if (File.Exists(outputPath))
            {
                OverWriteFile(outputPath);
            }
            analyzeSolution(outputPath, solutionPath);
            
        }
        protected static void loadFilters()
        {
        }
        private static void OverWriteFile(string path)
        {
            Console.WriteLine("Do you want to overwrite existing output file? (y/n)");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                File.Delete(path);
                Console.WriteLine("");
            }
            else
            {
                Environment.Exit(-1);
            }
        }
        public static void analyzeSolution(string outputPath, string solutionPath)
        {
            Console.WriteLine("Analyzing file...");
            System.IO.StreamWriter writer = new System.IO.StreamWriter(outputPath);
            
            ScanHardcodedFromSolution(solutionPath, (n, s) =>
            {
                string syntaxLineSpan = n.SyntaxTree.GetLineSpan(n.FullSpan).ToString();
                if (!filter.IsMatch(syntaxLineSpan))
                {
                    writer.WriteLine(" " + syntaxLineSpan + ": \r\n" + s + "\r\n\r\n");
                }
            }).Wait();
            writer.Close();
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
            if (text == "")
                return true;
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
    
    public class Filter
    {
        protected string[] patterns;
        public Filter(string path)
        {
            loadFilters(path);
        }
        protected void loadFilters(string path)
        {
            patterns = File.ReadAllLines(path);
        }
        public bool IsMatch(string input)
        {
            foreach (string pattern in patterns)
            {
                if(Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
