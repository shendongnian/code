    public class ResponseStuff
	{
		public static void ClientRedirect(Page page,string url)
		{
			string script = "<script type='text/javascript' runat='client'>$(function() {window.location='" + page.ResolveUrl(url) + "';});</script>";
			page.RegisterClientScriptBlock("client_redirect",script);
		}
	}
