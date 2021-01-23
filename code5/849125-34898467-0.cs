    var baseUrl = string.Format("{0}://{1}", Request.Url.Scheme, Request.Url.Authority);
    
    var html = ...;
    				
    Response.Clear();
    Response.ClearContent();
    Response.ClearHeaders();
    
    Response.ContentEncoding = Encoding.UTF8;
    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}.pdf", fileName));
    Response.ContentType = "application/pdf";
    
    using (var ms = new MemoryStream())
    {
    
    	using (var doc = new Document())
    	{						
    		using (var writer = PdfWriter.GetInstance(doc, ms))
    		{
    			doc.Open();
    
    			var rootProvider = new CustomRootProvider(baseUrl, Request.PhysicalApplicationPath); //Server.MapPath(Request.ApplicationPath)
    										
    			FontFactory.RegisterDirectories();
    
    			var htmlContext = new HtmlPipelineContext(null);
    
    			htmlContext.SetTagFactory(Tags.GetHtmlTagProcessorFactory());							
    
    			htmlContext.SetImageProvider(rootProvider);
    
    			htmlContext.SetLinkProvider(rootProvider);
    
    			htmlContext.CharSet(Encoding.UTF8);
    
    			var cssResolver = XMLWorkerHelper.GetInstance().GetDefaultCssResolver(true);
    
    			var pipeline = new CssResolverPipeline(cssResolver,
    
    			new HtmlPipeline(htmlContext, new PdfWriterPipeline(doc, writer)));
    
    			var worker = new XMLWorker(pipeline, true);
    
    			var p = new XMLParser(worker);
    
    			using(var htmlStream = new MemoryStream(Encoding.UTF8.GetBytes(html)))
    			{
    				p.Parse(htmlStream, Encoding.UTF8);							
    			}		
    
    			writer.CloseStream = false;
    		}
    		doc.Close();
    	}
    	ms.Position = 0;					
    	Response.BinaryWrite(ms.ToArray());
    }
    
    Response.Flush();
    Response.End();
    
    ...
    
    public class CustomRootProvider : AbstractImageProvider, ILinkProvider
    {
    	private string _baseUrl;
    	private string _basePath;
    	public CustomRootProvider(string baseUrl, string basePath)
    	{
    		_baseUrl = baseUrl;		
    	}
    
    	public override Image Retrieve(string src)
    	{		
    		var siteUrl = string.IsNullOrEmpty(_baseUrl) ? HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.PathAndQuery, string.Empty) : _baseUrl;
    
    		siteUrl = VirtualPathUtility.RemoveTrailingSlash(siteUrl);		
    		
    		if (Uri.IsWellFormedUriString(src, UriKind.Relative))
    		{
    			src = new Uri(new Uri(siteUrl), src).ToString();			
    		}
    
    		try
    		{
    			return Image.GetInstance(src);
    		}
    		catch (Exception)
    		{						
    			return Image.GetInstance(new Uri(new Uri(siteUrl), "/Content/Images/noimage.png").ToString());
    		}
    		
    	}
    
    	public override string GetImageRootPath()
    	{
    		return string.IsNullOrEmpty(_basePath) ? HttpContext.Current.Request.PhysicalApplicationPath : _basePath;
    		//HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath);
    	}
    
    	public string GetLinkRoot()
    	{
    		return string.IsNullOrEmpty(_baseUrl)
    			? HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.PathAndQuery, string.Empty)
    			: _baseUrl;
    	}
    }
