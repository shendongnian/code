        public static string[] GetLatestVersion(params string[] files)
        {
            System.Collections.Generic.List<string> latestFiles = new System.Collections.Generic.List<string>();
            foreach (var file in files)
            {
                var folder = System.IO.Path.GetDirectoryName(file);
                var phisicalFolder = System.Web.HttpContext.Current.Server.MapPath(folder);
                var pattern = System.IO.Path.GetFileName(file).Replace("{version}", "*");
                var virtualFile = folder.Replace("\\","/") + "/" + System.IO.Path.GetFileName(System.Linq.Enumerable.First(System.Linq.Enumerable.OrderByDescending(System.IO.Directory.GetFiles(phisicalFolder, pattern), x => x)));
                latestFiles.Add(virtualFile);
            }
            return latestFiles.ToArray();
        }
        public static void RegisterBundles(BundleCollection bundles)
        {
  
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        GetLatestVersion("~/Scripts/modernizr-{version}.js")));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        GetLatestVersion("~/Scripts/jquery-*.js")));
        }
