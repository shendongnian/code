    SyntaxNode newSource = rewriter.Visit(sourceTree.GetRoot());
    if (newSource != sourceTree.GetRoot())
    {
        File.WriteAllText(sourceTree.FilePath, newSource.GetFullText());
    }
