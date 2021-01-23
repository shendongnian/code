    using System.Linq;
    using Roslyn.Compilers.CSharp;
    // Snip some console app wrapping
    var code = @"
        public void FindI()
        {
            int[] tab1 = { 0, 1, 2, 3, 4 };
            for (var i = 0; i < tab1.Length - 1; i++) { };
        }";
            var syntaxTree = SyntaxTree.ParseText(code);
            var forStatement = syntaxTree
                .GetRoot()
                .DescendantNodes()
                .OfType<ForStatementSyntax>()
                .First();
            // Gets the name 'tab1' from the for statement condition
            var conditionMemberName = forStatement
                .DescendantNodes()
                .OfType<MemberAccessExpressionSyntax>()
                .First()
                .GetFirstToken()
                .Value;
            // Finds the first variable: int[] tab1 = { 0, 1, 2, 3, 4 };
            var member = syntaxTree
                .GetRoot()
                .DescendantNodes()
                .OfType<VariableDeclarationSyntax>()
                .First()
            // Finds the variable with the correct name 'tab1'
            var variable = member.Variables.Where(x => x.Identifier.Value == conditionMemberName).Single();
            // Find the initializer: { 0, 1, 2, 3, 4 };
            var initializer = variable.Initializer.Value as InitializerExpressionSyntax;
            // Counds the number of items in the initializer
            var lengthOfInitializers = initializer.Expressions.Count;
