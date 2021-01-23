    using System;
    using System.Linq;
    using System.IO;
    using System.IO.IsolatedStorage;
    using System.Collections.Generic;
    using Microsoft.LightSwitch;
    using Microsoft.LightSwitch.Framework.Client;
    using Microsoft.LightSwitch.Presentation;
    using Microsoft.LightSwitch.Presentation.Extensions;
    using System.Windows;
    using Microsoft.LightSwitch.Threading;
    using HtmlAgilityPack;
    namespace LightSwitchApplication
    {
    public partial class Table1ItemsListDetail
    {
        partial void Method_CanExecute(ref bool result)
        {
            // Write your code here.
        
            
        }
        partial void Method_Execute()
        {
                var wc = new HtmlWeb();
                // string url = "http://www.nu.nl/feeds/rss/algemeen.rss";
                wc.LoadAsync("http://google.com");
            
                wc.LoadCompleted += new EventHandler<HtmlDocumentLoadCompleted>(DownloadCompleted);
                //wc.
            //
        }
        void DownloadCompleted(object sender, HtmlDocumentLoadCompleted e)
        {
            if (e.Error == null)
            {
                HtmlDocument doc = e.Document;
                if (doc != null)
                {
                    Dispatchers.Main.BeginInvoke(() =>
                    {
                        MessageBox.Show(doc.DocumentNode.Element("html").InnerHtml);
                    });
                }
            }
        }
    }
}
