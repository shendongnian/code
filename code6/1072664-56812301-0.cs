    var cw = new AdhocWorkspace();
    cw.Options.WithChangedOption(CSharpFormattingOptions.IndentBraces, true);
    var formatter = Formatter.Format(cu, cw);
    StringBuilder sb = new StringBuilder();
    using (StringWriter writer = new StringWriter(sb))
    {
        formatter.WriteTo(writer);
    }
    var code = sb.ToString();
