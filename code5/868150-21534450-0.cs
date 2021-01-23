    // Credit: Awesomium v1.7.2 C# Basic Sample
    //         by Perikles C. Stephanidis
    using System;
    using Awesomium.Core;
    using System.Threading;
    using System.Diagnostics;
    using System.Reflection;
    namespace BasicSample
    {
        class Program
        {
            static void Main( string[] args )
            {
                WebCore.Initialize(WebConfig.Default);
                Uri url = new Uri("http://www.google.com");
                using ( WebSession session = WebCore.CreateWebSession(WebPreferences.Default) )
                {
                    // WebView implements IDisposable. Here we demonstrate
                    // wrapping it in a using statement.
                    using ( WebView view = WebCore.CreateWebView( 1100, 600, session ) )
                    {
                        bool finishedLoading = false;
                        bool finishedResizing = false;
                        Console.WriteLine( String.Format( "Loading: {0} ...", url ) );
                        // Load a URL.
                        view.Source = url;
                        // This event is fired when a frame in the
                        // page finished loading.
                        view.LoadingFrameComplete += ( s, e ) =>
                        {
                            Console.WriteLine( String.Format( "Frame Loaded: {0}", e.FrameId ) );
                            // The main frame usually finishes loading last for a given page load.
                            if ( e.IsMainFrame )
                                finishedLoading = true;
                        };
                        while ( !finishedLoading )
                        {
                            Thread.Sleep( 100 );
                            // A Console application does not have a synchronization
                            // context, thus auto-update won't be enabled on WebCore.
                            // We need to manually call Update here.
                            WebCore.Update();
                        }
                        // Print some more information.
                        Console.WriteLine( String.Format( "Page Title: {0}", view.Title ) );
                        Console.WriteLine( String.Format( "Loaded URL: {0}", view.Source ) );
                    } // Destroy and dispose the view.
                } // Release and dispose the session.            
                // Shut down Awesomium before exiting.
                WebCore.Shutdown();
                Console.WriteLine("Press any key to exit...");
                Console.Read();
            }
        }
    }
