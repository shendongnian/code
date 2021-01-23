    StringBuilder sb = new StringBuilder();
    foreach (string s in Assembly.GetEntryAssembly().GetManifestResourceNames())
       sb.AppendLine(s);
    
    MessageBox.Show(sb.ToString());
