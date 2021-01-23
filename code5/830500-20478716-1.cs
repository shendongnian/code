    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    namespace UnitTestProject3
    {
        using System.Net;
        using System.Runtime;
    
        using HtmlAgilityPack;
    
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void WhenProvidingCookiesYouSeeContent()
            {
                HtmlDocument doc = new HtmlDocument();
                
                WebClient wc = new WebClientEx(new CookieContainer());
    
                string contents = wc.DownloadString(
                    "http://www.nytimes.com/2013/12/10/world/asia/thailand-protests.html?partner=rss&emc=rss&_r=1&");
                doc.LoadHtml(contents);
    
                var nodes = doc.DocumentNode.SelectNodes(@"//p[@itemprop='articleBody']");
                
                Assert.IsNotNull(nodes);
                Assert.IsTrue(nodes.Count > 0);
            }
        }
        public class WebClientEx : WebClient
        {
            public WebClientEx(CookieContainer container)
            {
                this.container = container;
            }
    
            private readonly CookieContainer container = new CookieContainer();
    
            protected override WebRequest GetWebRequest(Uri address)
            {
                WebRequest r = base.GetWebRequest(address);
                var request = r as HttpWebRequest;
                if (request != null)
                {
                    request.CookieContainer = container;
                }
                return r;
            }
    
            protected override WebResponse GetWebResponse(WebRequest request, IAsyncResult result)
            {
                WebResponse response = base.GetWebResponse(request, result);
                ReadCookies(response);
                return response;
            }
    
            protected override WebResponse GetWebResponse(WebRequest request)
            {
                WebResponse response = base.GetWebResponse(request);
                ReadCookies(response);
                return response;
            }
    
            private void ReadCookies(WebResponse r)
            {
                var response = r as HttpWebResponse;
                if (response != null)
                {
                    CookieCollection cookies = response.Cookies;
                    container.Add(cookies);
                }
            }
        }
    }
