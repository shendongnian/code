    public MvcHtmlString BundleScript(string bundleUrl)
    {
            var javascriptBuilder = new StringBuilder();
            bool filesExist = false;
            bool isDynamicEnabled = IsDynamicEnabled();
            if (!isDynamicEnabled)
            {
                IEnumerable<string> fileUrls = GetBundleFilesCollection(bundleUrl);
                string rootVirtualDirectory = "~/content/js/";
                if (fileUrls != null)
                {
                    foreach (string fileUrl in fileUrls)
                    {
                        javascriptBuilder.Append(new ScriptTag().WithSource(GetScriptName(fileUrl, rootVirtualDirectory)).ToHtmlString());
                    }
                    filesExist = true;
                }
            }
            if (isDynamicEnabled || !filesExist)
            {
                javascriptBuilder.Append(new ScriptTag().WithSource(bundleUrl).ToHtmlString());
            }
            return MvcHtmlString.Create(javascriptBuilder.ToString());
    }
    private IEnumerable<string> GetBundleFilesCollection(string bundleVirtualPath)
    {
            var collection = new BundleCollection { BundleTable.Bundles.GetBundleFor(bundleVirtualPath) };
            var bundleResolver = new BundleResolver(collection);
            return bundleResolver.GetBundleContents(bundleVirtualPath);
    }
    private bool IsDynamicEnabled()
    {
            return BundleTable.EnableOptimizations;
    }
    private static string GetScriptName(string scriptUrl, string virtualDirectory)
    {
            return scriptUrl.Replace(virtualDirectory, string.Empty);
    }
