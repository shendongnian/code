    static class SyntaxNodeHelper
    {
        public static bool TryGetParentSyntax<T>(SyntaxNode syntaxNode, out T result) 
            where T : SyntaxNode
        {
            // set defaults
            result = null;
    
            if (syntaxNode == null)
            {
                return false;
            }
    
             bool foundParentSyntax = false;
    
             while (!foundParentSyntax)
             {
                try
                {
                    syntaxNode = syntaxNode.Parent;
                    if (syntaxNode != null && syntaxNode.GetType() == typeof(T))
                    {
                         result = syntaxNode as T;
                         foundParentSyntax = true;
                    }
                 }
                 catch
                 {
                        return foundParentSyntax;
                 }
              }
    
              return true;
            }
        }
    }
