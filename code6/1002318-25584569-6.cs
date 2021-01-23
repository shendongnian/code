    var root = SyntaxFactory.ParseCompilationUnit(
    @"using System;
    using System.Collections.Generic;
    using System.Text;
    
    static void Main(string[] args)
    {
        for(int i=0; i<10; i++)
            int a = i;
    }");
    var rewritten = new Rewriter().Visit(root);
