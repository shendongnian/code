    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    
    using WPCordovaClassLib.Cordova;
    using WPCordovaClassLib.Cordova.Commands;
    
    namespace Cordova.Extension.Commands
    {
        public class Jumper : BaseCommand
        {
            /** Instruct the browser component to go to beginning. */
            public void goHome(string unused)
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    var webview = WebViewHandler.getInstance().webView;
                    webview.CordovaBrowser.Navigate(webview.StartPageUri);
                });
            }
        }
    }
