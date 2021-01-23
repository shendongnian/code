    internal class SyntaxTemplate
    {
        public ExpressionSyntax Syntax { get; private set; }
        private readonly ImmutableDictionary<string, ImmutableList<IdentifierNameSyntax>> _identifiers;
        public SyntaxTemplate(string source)
        {
            Syntax = SyntaxFactory.ParseExpression(source);
            var identifiers = ImmutableDictionary<string, ImmutableList<IdentifierNameSyntax>.Builder>.Empty.ToBuilder();
            foreach (var node in Syntax.DescendantNodes().OfType<IdentifierNameSyntax>())
            {
                ImmutableList<IdentifierNameSyntax>.Builder list;
                if (!identifiers.TryGetValue(node.Identifier.Text, out list))
                    list = identifiers[node.Identifier.Text] = 
                        ImmutableList<IdentifierNameSyntax>.Empty.ToBuilder();
                list.Add(node);
            }
            _identifiers = identifiers.ToImmutableDictionary(
                p => p.Key, p => p.Value.ToImmutableList());
        }
        private SyntaxTemplate(ExpressionSyntax syntax,
            ImmutableDictionary<string, ImmutableList<IdentifierNameSyntax>> identifiers)
        {
            Syntax = syntax;
            _identifiers = identifiers;
        }
        public SyntaxTemplate Replace(string identifier, SyntaxNode value)
        {
            return new SyntaxTemplate(
                Syntax.ReplaceNodes(_identifiers[identifier], (o1, o2) => value),
                _identifiers.Remove(identifier));
        }
    }
