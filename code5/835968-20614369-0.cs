    System.Text.StringBuilder sb = new StringBuilder();
    sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
    sb.AppendLine("<configuration>");
    sb.AppendLine("</configuration>");
    string loc = Assembly.GetEntryAssembly().Location;
    System.IO.File.WriteAllText(String.Concat(loc, ".config"), sb.toString());
