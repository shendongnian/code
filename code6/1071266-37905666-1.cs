	public class CustomContextHandler : IContextMenuHandler
	{
		public void OnBeforeContextMenu(IWebBrowser browserControl, CefSharp.IBrowser browser, IFrame frame, IContextMenuParams parameters,
			IMenuModel model)
		{
			model.Clear();
		}
		public bool OnContextMenuCommand(IWebBrowser browserControl, CefSharp.IBrowser browser, IFrame frame, IContextMenuParams parameters,
			CefMenuCommand commandId, CefEventFlags eventFlags)
		{
			return false;
		}
		public void OnContextMenuDismissed(IWebBrowser browserControl, CefSharp.IBrowser browser, IFrame frame)
		{
		}
	}
	
