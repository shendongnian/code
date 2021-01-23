    using System;
    using System.IO;
    using System.Linq;
    using Roslyn.Compilers.CSharp;
    using Roslyn.Services;
    
    namespace TrailingSemicolon
    {
      class Program
      {
        static void Main(string[] args)
        {
          string solutionfile = @"c:\temp\mysolution.sln";
          var workspace = Workspace.LoadSolution(solutionfile);
          var solution = workspace.CurrentSolution;
    
          var rewriter = new TrailingSemicolonRewriter();
    
          foreach (var project in solution.Projects)
          {
            foreach (var document in project.Documents)
            {
              SyntaxTree tree = (SyntaxTree)document.GetSyntaxTree();
    
              var newSource = rewriter.Visit(tree.GetRoot());
    
              if (newSource != tree.GetRoot())
              {
                File.WriteAllText(tree.FilePath, newSource.GetText().ToString());
              }
            }
          }
        }
    
        class TrailingSemicolonRewriter : SyntaxRewriter
        {
          public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
          {
            return RemoveSemicolon(node, node.SemicolonToken, t => node.WithSemicolonToken(t));
          }
    
          public override SyntaxNode VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
          {
            return RemoveSemicolon(node, node.SemicolonToken, t => node.WithSemicolonToken(t));
          }
    
          public override SyntaxNode VisitStructDeclaration(StructDeclarationSyntax node)
          {
            return RemoveSemicolon(node, node.SemicolonToken, t => node.WithSemicolonToken(t));
          }
    
          public override SyntaxNode VisitEnumDeclaration(EnumDeclarationSyntax node)
          {
            return RemoveSemicolon(node, node.SemicolonToken, t => node.WithSemicolonToken(t));
          }
    
          private SyntaxNode RemoveSemicolon(SyntaxNode node,
                                             SyntaxToken semicolonToken,
                                             Func<SyntaxToken, SyntaxNode> withSemicolonToken)
          {
            if (semicolonToken.Kind != SyntaxKind.None)
            {
              var leadingTrivia = semicolonToken.LeadingTrivia;
              var trailingTrivia = semicolonToken.TrailingTrivia;
    
              SyntaxToken newToken = Syntax.Token(
                leadingTrivia,
                SyntaxKind.None,
                trailingTrivia);
    
              bool addNewline = semicolonToken.HasTrailingTrivia
                && trailingTrivia.Count() == 1
                && trailingTrivia.First().Kind == SyntaxKind.EndOfLineTrivia;
    
              var newNode = withSemicolonToken(newToken);
    
              if (addNewline)
                return newNode.WithTrailingTrivia(Syntax.Whitespace(Environment.NewLine));
              else
                return newNode;
            }
            return node;
          }
        }
      }
    }
