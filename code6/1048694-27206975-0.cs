	using System;
	using System.Configuration;
	using System.IO;
	using System.Linq;
	using System.Net;
	using System.Text;
	using System.Web;
	using System.Web.Mvc;
	using System.Web.Routing;
	public static class HtmlHelperExtensions
	{
		public static IHtmlString RenderActionToSpecifiedAssembly(
            this HtmlHelper helper, string actionName, string parentAssembly)
		{
			return RenderActionToSpecifiedAssembly(
                helper, actionName, null, null, null, parentAssembly);
		}
		public static IHtmlString RenderActionToSpecifiedAssembly(
            this HtmlHelper helper, string actionName, object routeValues, 
            string parentAssembly)
		{
			return RenderActionToSpecifiedAssembly(helper, actionName, 
                null, new RouteValueDictionary(routeValues), null, parentAssembly);
		}
		public static IHtmlString RenderActionToSpecifiedAssembly(
            this HtmlHelper helper, string actionName, string controllerName, 
            string parentAssembly)
		{
			return RenderActionToSpecifiedAssembly(helper, actionName, 
                controllerName, null, null, parentAssembly);
		}
		public static IHtmlString RenderActionToSpecifiedAssembly(
            this HtmlHelper helper, string actionName, RouteValueDictionary routeValues, 
            string parentAssembly)
		{
			return RenderActionToSpecifiedAssembly(helper, actionName, 
                null, routeValues, null, parentAssembly);
		}
		public static IHtmlString RenderActionToSpecifiedAssembly(
            this HtmlHelper helper, string actionName, string controllerName, 
            object routeValues, string parentAssembly)
		{
			return RenderActionToSpecifiedAssembly(helper, actionName, 
                controllerName, new RouteValueDictionary(routeValues), 
                null, parentAssembly);
		}
		public static IHtmlString RenderActionToSpecifiedAssembly(
            this HtmlHelper helper, string actionName, string controllerName, 
            RouteValueDictionary routeValues, string parentAssembly)
		{
			return RenderActionToSpecifiedAssembly(helper, actionName, 
                controllerName, routeValues, parentAssembly, null);
		}
		public static IHtmlString RenderActionToSpecifiedAssembly(
            this HtmlHelper helper, string actionName, string controllerName, 
            object routeValues, string protocol, string parentAssembly)
		{
			return RenderActionToSpecifiedAssembly(helper, actionName, 
                controllerName, routeValues, protocol, parentAssembly, null);
		}
		public static IHtmlString RenderActionToSpecifiedAssembly(
            this HtmlHelper helper, string actionName, string controllerName, 
            RouteValueDictionary routeValues, string parentAssembly, string port)
		{
			var hostName = ConfigurationManager.AppSettings[parentAssembly];
			var url = GenerateContentUrl(helper, actionName, 
                controllerName, routeValues, null, hostName, port);
			return RenderContents(url);
		}
		public static IHtmlString RenderActionToSpecifiedAssembly(
            this HtmlHelper helper, string actionName, string controllerName, 
            object routeValues, string protocol, string parentAssembly, string port)
		{
			var hostName = ConfigurationManager.AppSettings[parentAssembly];
			var url = GenerateContentUrl(helper, actionName, 
                controllerName, new RouteValueDictionary(routeValues), 
                protocol, hostName, port);
			return RenderContents(url);
		}
		private static string GenerateContentUrl(this HtmlHelper helper, 
            string actionName, string controllerName, RouteValueDictionary routeValues, 
            string protocol, string hostName, string port)
		{
			var currentUri = helper.ViewContext.RequestContext.HttpContext.Request.Url;
			// Ensure we have an absolute path
			if (string.IsNullOrEmpty(protocol) && string.IsNullOrEmpty(hostName))
			{
				// Match the scheme of the current request so we don't get a
				// security warning in the browser.
				protocol = currentUri.Scheme;
			}
			// Allow caller to override the port so it doesn't have 
            // to be the same as the current request.
			string currentUrl = currentUri.Scheme + Uri.SchemeDelimiter 
                + currentUri.DnsSafeHost;
			if (!string.IsNullOrEmpty(port))
			{
				currentUrl += ":" + port;
			}
			currentUrl += "/";
			var homePageUri = new Uri(new Uri(currentUrl, UriKind.Absolute), "/");
			// Create a TextWriter with null stream as a backing stream 
			// which doesn't consume resources
			using (var nullWriter = new StreamWriter(Stream.Null))
			{
				// Create a fake context at the home page to ensure that ambient values  
				// from the request are excluded from the generated URL.
				// See: https://aspnetwebstack.codeplex.com/workitem/1346
				var httpContext = CreateHttpContext(homePageUri, nullWriter);
				var requestContext = new RequestContext(httpContext, new RouteData());
				return UrlHelper.GenerateUrl(null, actionName, controllerName, 
                    protocol, hostName, null, routeValues, helper.RouteCollection, 
                    requestContext, true);
			}
		}
		private static HttpContextBase CreateHttpContext(Uri uri, TextWriter writer)
		{
			if (uri == null)
				throw new ArgumentNullException("uri");
			if (writer == null)
				throw new ArgumentNullException("writer");
			var request = new HttpRequest(string.Empty, uri.ToString(), uri.Query);
			var response = new HttpResponse(writer);
			var httpContext = new HttpContext(request, response);
			return new HttpContextWrapper(httpContext);
		}
		private static IHtmlString RenderContents(string url)
		{
			var request = (HttpWebRequest)WebRequest.Create(url);
			var result = (HttpWebResponse)request.GetResponse();
			String responseString;
			using (Stream stream = result.GetResponseStream())
			{
				StreamReader reader = new StreamReader(stream, Encoding.UTF8);
				responseString = reader.ReadToEnd();
			}
			return new HtmlString(responseString);
		}
	}
