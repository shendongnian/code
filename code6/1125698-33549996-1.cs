    using System;
    using Awesomium.Core;
	class MainClass
	{
		public static void Main (string[] args)
		{
			using (var webView = WebCore.CreateWebView( 800, 600 ) )
			{
				webView.Source = new Uri( "http://www.google.com" );
				webView.LoadingFrameComplete += ( s, e ) =>
				{
					if (!e.IsMainFrame)
						return;
					BitmapSurface surface = (BitmapSurface)webView.Surface;
					surface.SaveToPNG ("result.png", true);
					WebCore.Shutdown ();
				};
			}
			WebCore.Run();
		}
	}
