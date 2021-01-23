    foreach (var t in tree.GetCompilationUnitRoot().DescendantTokens())
	{
		
		if (t.HasLeadingTrivia)
		{
			file.Write(t.LeadingTrivia);
		}
		file.Write(t.IsKind(SyntaxKind.ForKeyword)? "foobar" : t.ToString());
		if (t.HasTrailingTrivia)
		{
			file.Write(t.TrailingTrivia);
		}
		
	}
