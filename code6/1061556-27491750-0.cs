    var tree  = CSharpSyntaxTree.ParseText(
    // The trailing newline might help keep indentation on the first line correct
    @"
         Func<string, string> parser = value =>
         {
             return string.Format(""Hello {0}"", value);
         };" // Not this string ends here
    );
    
    var root = (CompilationUnitSyntax)tree.GetRoot();
    var result = root.NormalizeWhitespace().GetText().ToString();
