    public void Process(BundleContext context, BundleResponse bundle)
            {
                if (context == null)
                {
                    throw new ArgumentNullException("context");
                }
    
                if (bundle == null)
                {
                    throw new ArgumentNullException("bundle");
                }
    
                context.HttpContext.Response.Cache.SetLastModifiedFromFileDependencies();
    
                var lessParser = new Parser();
                var lessEngine = this.CreateLessEngine(lessParser);
    
                var content = new StringBuilder(bundle.Content.Length);
    
                var bundleFiles = new List<BundleFile>();
    
                foreach (var bundleFile in bundle.Files)
                {
                    bundleFiles.Add(bundleFile);
                    var filePath = bundleFile.IncludedVirtualPath;
                    filePath = filePath.Replace('\\', '/');
                    if (filePath.StartsWith("~"))
                    {
                        filePath = VirtualPathUtility.ToAbsolute(filePath);
                    }
    
                    if (filePath.StartsWith("/"))
                    {
                        filePath = HostingEnvironment.MapPath(filePath);
                    }
    
                    this.SetCurrentFilePath(lessParser, filePath);
                    var source = File.ReadAllText(filePath);
                    var transformContent = lessEngine.TransformToCss(source, filePath);
                    foreach (var transform in bundleFile.Transforms)
                    {
                        transformContent = transform.Process(bundleFile.IncludedVirtualPath, transformContent);
                    }
    
                    content.Append(transformContent);
                    content.AppendLine();
    
                    bundleFiles.AddRange(this.GetFileDependencies(lessParser, bundleFile.VirtualFile));
                }
    
                if (BundleTable.EnableOptimizations)
                {
                    // include imports in bundle files to register cache dependencies
                    bundle.Files = bundleFiles.Distinct();
                }
    
                bundle.ContentType = "text/css";
                bundle.Content = content.ToString();
            }
