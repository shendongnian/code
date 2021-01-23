    public class CustomScriptBundle : Bundle
    {
        public CustomScriptBundle(string virtualPath)
            : this(virtualPath, null)
        {
        }
        public CustomScriptBundle(string virtualPath, string cdnPath)
            : base(virtualPath, cdnPath, null)
        {
            this.ConcatenationToken = ";" + Environment.NewLine;
            this.Builder = new CustomBundleBuilder();
        }
    }
    public class CustomBundleBuilder : IBundleBuilder
    {
        internal static string ConvertToAppRelativePath(string appPath, string fullName)
        {
            return (string.IsNullOrEmpty(appPath) || !fullName.StartsWith(appPath, StringComparison.OrdinalIgnoreCase) ? fullName : fullName.Replace(appPath, "~/")).Replace('\\', '/');
        }
        public string BuildBundleContent(Bundle bundle, BundleContext context, IEnumerable<BundleFile> files)
        {
            if (files == null)
                return string.Empty;
            if (context == null)
                throw new ArgumentNullException("context");
            if (bundle == null)
                throw new ArgumentNullException("bundle");
            StringBuilder stringBuilder = new StringBuilder();
            foreach (BundleFile bundleFile in files)
            {
                bundleFile.Transforms.Add(new CustomJsMinify());
                stringBuilder.Append(bundleFile.ApplyTransforms());
                stringBuilder.Append(bundle.ConcatenationToken);
            }
            return stringBuilder.ToString();
        }
    }
    public class CustomJsMinify : IItemTransform
    {
        public string Process(string includedVirtualPath, string input)
        {
            if (includedVirtualPath.EndsWith("min.js", StringComparison.OrdinalIgnoreCase))
            {
                return input;
            }
            Minifier minifier = new Minifier();
            var codeSettings = new CodeSettings();
            codeSettings.EvalTreatment = EvalTreatment.MakeImmediateSafe;
            codeSettings.PreserveImportantComments = false;
            string str = minifier.MinifyJavaScript(input, codeSettings);
            if (minifier.ErrorList.Count > 0)
                return "/* " + string.Concat(minifier.Errors) + " */";
            return str;
        }
    }
