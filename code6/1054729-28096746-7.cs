    class CustomScriptBundleBuilder : IBundleBuilder
    {
        private string Read(BundleFile file)
        {
            FileInfo fileInfo = new FileInfo(HttpContext.Current.Server.MapPath(@file.IncludedVirtualPath));
            using (var reader = fileInfo.OpenText())
            {
                return reader.ReadToEnd();
            }
        }
        public string BuildBundleContent(Bundle bundle, BundleContext context, IEnumerable<BundleFile> files)
        {
            var content = new StringBuilder();
            foreach (var fileInfo in files)
            {
                var contents = new StringBuilder(Read(fileInfo));
                const string pattern = @"\bcatch\b(\s*)*\((?<errVariable>([^)])*)\)(\s*)*\{(?<blockContent>([^{}])*(\{([^}])*\})*([^}])*)\}";
                
                var regex = new Regex(pattern);
                var matches = regex.Matches(contents.ToString());
                for (var i = matches.Count - 1; i >= 0; i--)
                {
                    var match = matches[i];
                    
                    var errVariable = match.Groups["errVariable"].ToString();
                    var blockContentIndex = match.Groups["blockContent"].Index;
                    var hasContent = match.Groups["blockContent"].Length > 2;
                    contents.Insert(blockContentIndex,
                              string.Format("if(customErrorLogging)customErrorLogging({0}){1}", errVariable, hasContent ? ";" : ""));
                }
                var parser = new JSParser(contents.ToString());
                var bundleValue = parser.Parse(parser.Settings).ToCode();
                content.Append(bundleValue);
                content.AppendLine(";");
            }
            return content.ToString();
        }
    }
