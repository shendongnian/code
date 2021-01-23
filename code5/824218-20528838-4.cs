    @{
        var context = new BundleContext(this.Context, BundleTable.Bundles, string.Empty);
        var bundle = BundleTable.Bundles.GetBundleFor("~/VIRTUALPATH");
        if (BundleTable.EnableOptimizations)
        {
            var response = bundle.GenerateBundleResponse(context);
            var content = response.Content;
            this.WriteLiteral(content);
        }
        else
        {
            var files = bundle.EnumerateFiles(context);
            foreach (var file in files)
            {
                var stream = file.VirtualFile.Open();
                using (var reader = new StreamReader(stream))
                {
                    this.Output.Write("{0}{1}", reader.ReadToEnd(), bundle.ConcatenationToken);
                }
            }
        }
    }
