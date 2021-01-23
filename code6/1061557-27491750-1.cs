    var tree  = CSharpSyntaxTree.ParseText(
    (@"
         Func<string, string> parser = value =>
         {
             return string.Format(""Hello {0}"", value);
         };
    ").Trim());    // This could also be .Trim('\n') to only remove the newlines before and after the text
    
    var root = (CompilationUnitSyntax)tree.GetRoot();
    var result = root.NormalizeWhitespace().GetText().ToString();
