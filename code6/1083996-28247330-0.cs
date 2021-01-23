	public class BaseClassRewriter : CSharpSyntaxRewriter
	{
		private readonly SemanticModel _model;
		public BaseClassRewriter(SemanticModel model)
		{
			_model = model;
		}
		public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
		{
			var symbol = _model.GetDeclaredSymbol(node);
			if (InheritsFrom<BaseClass>(symbol))
			{
                // hit!
            }
        }
        private bool InheritsFrom<T>(INamedTypeSymbol symbol)
		{
			while (true)
			{
				if (symbol.ToString() == typeof(T).FullName)
				{
					return true;
				}
				if (symbol.BaseType != null)
				{
					symbol = symbol.BaseType;
					continue;
				}
				break;
			}
			return false;
		}
    }
