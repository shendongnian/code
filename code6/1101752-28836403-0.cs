	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using MvcSiteMapProvider.IO;
	using MvcSiteMapProvider.Xml.Sitemap;
	using MvcSiteMapProvider.Xml.Sitemap.Configuration;
	public partial class XmlSitemap : System.Web.UI.Page
	{
		private HttpContextBase HttpContext
		{
			get { return new HttpContextWrapper(System.Web.HttpContext.Current); }
		}
		private int PageNumber
		{
			get
			{
				var pageString = HttpContext.Request.QueryString["page"];
				if (!string.IsNullOrEmpty(pageString))
				{
					int page;
					if (int.TryParse(pageString, out page))
					{
						return page;
					}
				}
				return 0;
			}
		}
		private string FeedName
		{
			get
			{
				var feedName = HttpContext.Request.QueryString["feedName"];
				if (!string.IsNullOrEmpty(feedName))
				{
					return feedName;
				}
				return "default";
			}
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			// Build feeds for XML sitemap
			var xmlSitemapFeedStrategy = new XmlSitemapFeedStrategyBuilder()
				.SetupPageNameTempates(templates => templates
					.WithDefaultFeedRoot("XmlSitemap.aspx?feedName={feedName}&page={page}")
					.WithDefaultFeedPaged("XmlSitemap.aspx?feedName={feedName}&page={page}")
					.WithNamedFeedRoot("XmlSitemap.aspx?feedName={feedName}&page={page}")
					.WithNamedFeedPaged("XmlSitemap.aspx?feedName={feedName}&page={page}"))
				.AddDefaultFeed()
				.AddNamedFeed("google", feed => feed.WithContent(c => c.Image().Video()))
				
				// Optional - add news feed (will be at ~/XmlSitemap.aspx?feedName=news)
				.AddNamedFeed("news", feed => feed.WithContent(c => c.News()))
				
				// Optional - add mobile feed (will be at ~/XmlSitemap.aspx?feedName=mobile)
				.AddNamedFeed("mobile", feed => feed.WithContent(c => c.Mobile()).WithMaximumPageSize(10000))
				.Create();
			var xmlSitemapFeed = xmlSitemapFeedStrategy.GetFeed(this.FeedName);
			if (xmlSitemapFeed != null)
			{
				var outputCompressor = new HttpResponseStreamCompressor();
				var response = HttpContext.Response;
				response.Clear();
				// Output content type
				response.ContentType = "text/xml";
				using (var stream = outputCompressor.Compress(HttpContext))
				{
					if (!xmlSitemapFeed.WritePage(this.PageNumber, stream))
					{
						context.Response.Clear();
						//Return 404 not found
						context.Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
						context.Response.StatusDescription = "Page Not Found";
					}
				}
				response.End();
			}
		}
	}
