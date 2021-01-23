public static string ListToCommandLine(IEnumerable&lt;string&gt; args)
{
    return string.Join(" ", args.Select(a =>
    {
        if (string.IsNullOrEmpty(a)) 
            return "\"\"";
              
        var sb = new StringBuilder();
       
        var needQuote = a.Contains(' ') || a.Contains('\t');
        if (needQuote)
            sb.Append('"');
        var backslashCount = 0;
       
        foreach (var c in a)
        {
            switch (c)
            {
                case '\\':
                    backslashCount++;
                    break;
              
                case '"':
                    sb.Append(new string('\\', backslashCount * 2));
                    backslashCount = 0;
                    break;
              
                default:
                    if (backslashCount &gt; 0)
                    {
                        sb.Append(new string('\\', backslashCount));
                        backslashCount = 0;
                    }
                 
                    sb.Append(c);
                    break;            
            }
            if (backslashCount &gt; 0)
                sb.Append(new string('\\', backslashCount * (needQuote ? 2 : 1)));
            if (needQuote)
                sb.Append('"');           
        }
       
        return sb.ToString();       
    }));
}
