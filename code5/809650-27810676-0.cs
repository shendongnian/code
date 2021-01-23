	BundleTable.EnableOptimizations = true; // I think is what's missing
	var cssBundle = new StyleBundle("~/Content/css")
		.Include("~/Content/site.less");
	cssBundle.Transforms.Add(new LessTransform());
	cssBundle.Transforms.Add(new CssMinify());
	
	bundles.Add(cssBundle);
