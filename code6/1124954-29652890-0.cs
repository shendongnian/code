    using FeedModel.Classes;
    using FeedModel.Helpers;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Xml.Linq;
    namespace FeedModel
    {
      public class FeedDiscovery
      {
        private delegate void HttpGetDelegate(IAsyncResult asynchronousResult);
        private enum FeedType { RSS, Atom, RDF }
        public void FindFeeds(SearchFeedsCallback callback, string searchString)
            {
                string url = "https://ajax.googleapis.com/ajax/services/feed/find";
                string args = string.Format("v=1.0&q={0}", searchString);
                httpGet(url, args, (IAsyncResult asynchronousResult) => 
                    {
                        try
                        {
                            HttpWebRequest sidrequest = (HttpWebRequest)asynchronousResult.AsyncState;
                            // End the operation            
                            HttpWebResponse response = (HttpWebResponse)sidrequest.EndGetResponse(asynchronousResult);
                            Stream streamResponse = response.GetResponseStream();
                            StreamReader streamRead = new StreamReader(streamResponse);
                            string subscriptionContent = streamRead.ReadToEnd();
                            // Close the stream object            
                            streamResponse.Close();
                            streamRead.Close();
                            // Release the HttpWebResponse            
                            response.Close();
                            JObject jobj = JObject.Parse(subscriptionContent);
                            JArray subscriptions = (JArray)((JObject)jobj["responseData"])["entries"];
                            List<FDFeedItem> feeds =
                                (from f in subscriptions
                                 select new FDFeedItem()
                                 {
                                     Title = WebBrowserHelper.StripHtml((string)f["title"]),
                                     XmlUrl = (string)f["url"],
                                     Description = WebBrowserHelper.StripHtml((string)f["contentSnippet"]),
                                     HtmlUrl = (string)f["link"],
                                 }).ToList();
                            callback(new SearchFeedsEventArgs(feeds)
                            {
                                Failed = false,
                                Error = "",
                            });
                           // return;
                        }
                        catch
                        {
                            callback(new SearchFeedsEventArgs(new List<FDFeedItem>())
                            {
                                Failed = true,
                                Error = "Failed",
                            });                    
                        }
                    });
            }
        public void FeedPreview(FeedPreviewCallback callback, string url)
        {
          try
          {
            httpGet(url, "", (IAsyncResult asynchronousResult) =>
            {
              try
              {
                HttpWebRequest sidrequest = (HttpWebRequest)asynchronousResult.AsyncState;
                // End the operation            
                HttpWebResponse response = (HttpWebResponse)sidrequest.EndGetResponse(asynchronousResult);
                Stream streamResponse = response.GetResponseStream();
                StreamReader streamRead = new StreamReader(streamResponse);
                string subscriptionContent = streamRead.ReadToEnd();
                XDocument doc = XDocument.Parse(subscriptionContent);
                FeedType feedType = FeedType.RSS;
                if (doc.Root.ToString().StartsWith("<feed xmlns") || doc.Root.ToString().StartsWith("2005/Atom\">"))
                  feedType = FeedType.Atom;
                List<Article> articles;
                string title = "";
                string description = "";
                switch (feedType)
                {
                  case FeedType.RSS:
                    articles = ParseRss(doc, out title, out description);
                    break;
                  case FeedType.RDF:
                    articles = ParseRdf(doc, out title, out description);
                    break;
                  case FeedType.Atom:
                    articles = ParseAtom(doc, out title, out description);
                    break;
                  default:
                    throw new NotSupportedException(string.Format("{0} is not supported", feedType.ToString()));
                }
                FDFeedItem feed = new FDFeedItem();
                feed.Title = title;
                feed.Description = description;
                feed.XmlUrl = url;
                
                callback(new FeedPreviewEventArgs(articles, feed)
                {
                  Failed = false,
                  Error = ""
                });
              }
              catch
              {
                callback(new FeedPreviewEventArgs(new List<Article>(), new FDFeedItem())
                {
                  Failed = true,
                  Error = "Failed to get articles"
                });
              }
            });
          }
          catch
          {
            callback(new FeedPreviewEventArgs(new List<Article>(), new FDFeedItem())
            {
              Failed = true,
              Error = "Failed"
            });
          }
        }
        public void GetFeedDetails(FeedDetailsCallback callback, string url)
        {
          try
          {
            httpGet(url, "", (IAsyncResult asynchronousResult) =>
            {
              try
              {
                HttpWebRequest sidrequest = (HttpWebRequest)asynchronousResult.AsyncState;
                // End the operation            
                HttpWebResponse response = (HttpWebResponse)sidrequest.EndGetResponse(asynchronousResult);
                Stream streamResponse = response.GetResponseStream();
                StreamReader streamRead = new StreamReader(streamResponse);
                string subscriptionContent = streamRead.ReadToEnd();
                XDocument doc = XDocument.Parse(subscriptionContent);
                callback(new FeedsDetailsEventArgs(new FDFeedItem())
                {
                  Failed = false,
                  Error = ""
                });
              }
              catch
              {
                callback(new FeedsDetailsEventArgs(new FDFeedItem())
                {
                  Failed = true,
                  Error = "Failed to get feed"
                });
              }
            });
          }
          catch
          {
            callback(new FeedsDetailsEventArgs(new FDFeedItem())
            {
              Failed = true,
              Error = "Failed"
            });
          }
        }
        private void httpGet(string requestUrl, string getArgs, HttpGetDelegate httpGetResponse)
        {
          string url = requestUrl;
          if (getArgs != "")
            url = string.Format("{0}?{1}", requestUrl, getArgs);
          HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
          request.Method = "GET";
          request.BeginGetResponse(new AsyncCallback(httpGetResponse), request);
        }
        /// <summary>
        /// Parses an Atom feed and returns a <see cref="IList&amp;lt;Item&amp;gt;"/>.
        /// </summary>
        private List<Article> ParseAtom(XDocument doc, out string title, out string description)
        {
          title = doc.Root.Elements().First(i => i.Name.LocalName == "title").Value;
          try
          {
            description = doc.Root.Elements().First(i => i.Name.LocalName == "subtitle").Value;
          }
          catch { description = ""; }
          try
          {
            var entries = from item in doc.Root.Elements().Where(i => i.Name.LocalName == "entry")
                          select new Article
                          {
                            Content = item.Elements().First(i => i.Name.LocalName == "content").Value,
                            Url = item.Elements().First(i => i.Name.LocalName == "link").Attribute("href").Value,
                            PublishedDate = ParseDate(item.Elements().First(i => i.Name.LocalName == "published").Value),
                            Title = item.Elements().First(i => i.Name.LocalName == "title").Value,
                            Summary = WebBrowserHelper.GetSummary(item.Elements().First(i => i.Name.LocalName == "content").Value),
                            CrawlTime = DateTime.ParseExact("01/01/1970", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                            Author = item.Elements().First(i => i.Name.LocalName == "author").Elements().First(i=> i.Name.LocalName == "name").Value ,
                            Read = false,
                            Starred = false,
                            FeedProviderName = "NewsBlur",
                            OpenMode = ArticleOpenMode.UseContent,
                            Image = WebBrowserHelper.ExtractFirstImageFromHTML(item.Elements().First(i => i.Name.LocalName == "content").Value),
                          };
            return entries.ToList();
          }
          catch
          {
            return new List<Article>();
          }
        }
        /// <summary>
        /// Parses an RSS feed and returns a <see cref="IList&amp;lt;Item&amp;gt;"/>.
        /// </summary>
        private List<Article> ParseRss(XDocument doc, out string title, out string description)
        {
          title = "";
          description = "";
          try
          {
            //XDocument doc = XDocument.Load(url);
            // RSS/Channel/item
           var root = doc.Root.Descendants().First(i => i.Name.LocalName == "channel"); //.Elements() .First(i => i.Name.LocalName == "description").Value;
           title = root.Elements().First(i => i.Name.LocalName == "title").Value;
           description = root.Elements().First(i => i.Name.LocalName == "description").Value;
           var entries = from item in root.Elements().Where(i => i.Name.LocalName == "item")
                          select new Article
                          {
                            Content = item.Elements().First(i => i.Name.LocalName == "description").Value,
                            Url = item.Elements().First(i => i.Name.LocalName == "link").Value,
                            PublishedDate = ParseDate(item.Elements().First(i => i.Name.LocalName == "pubDate").Value),
                            Title = item.Elements().First(i => i.Name.LocalName == "title").Value,
                            Summary = WebBrowserHelper.GetSummary(item.Elements().First(i => i.Name.LocalName == "description").Value),
                            //Author = WebBrowserHelper.GetSummary(item.Elements().First(i => i.Name.LocalName == "creator").Value),
                            Author = "",
                            Read = false,
                            Starred = false,
                            FeedProviderName = "NewsBlur",
                            OpenMode = ArticleOpenMode.UseContent,
                            Image = WebBrowserHelper.ExtractFirstImageFromHTML(item.Elements().First(i => i.Name.LocalName == "description").Value),
                          };
            return entries.ToList();
          }
          catch (Exception e)
          {
            return new List<Article>();
          }
        }
        /// <summary>
        /// Parses an RDF feed and returns a <see cref="IList&amp;lt;Item&amp;gt;"/>.
        /// </summary>
        private List<Article> ParseRdf(XDocument doc, out string title, out string description)
        {
          title = "";
          description = "";
          try
          {
            //XDocument doc = XDocument.Load(url);
            // <item> is under the root
            var entries = from item in doc.Root.Descendants().Where(i => i.Name.LocalName == "item")
                          select new Article
                          {
                            Content = item.Elements().First(i => i.Name.LocalName == "description").Value,
                            FeedUrl = item.Elements().First(i => i.Name.LocalName == "link").Value,
                            PublishedDate = ParseDate(item.Elements().First(i => i.Name.LocalName == "date").Value),
                            Title = item.Elements().First(i => i.Name.LocalName == "title").Value,
                            Summary = WebBrowserHelper.GetSummary(item.Elements().First(i => i.Name.LocalName == "description").Value),
                            Image = WebBrowserHelper.ExtractFirstImageFromHTML(item.Elements().First(i => i.Name.LocalName == "description").Value),
                            OpenMode = ArticleOpenMode.UseContent,
                          };
            return entries.ToList();
          }
          catch
          {
            return new List<Article>();
          }
        }
        private DateTime ParseDate(string date)
        {
          DateTime result;
          if (DateTime.TryParse(date, out result))
            return result;
          else
          {
            int i = date.LastIndexOf(" ");
            if (i > date.Length - 6)
            {
              date = date.Substring(0, i).Trim();
              if (DateTime.TryParse(date, out result))
                return result;
            }
            return DateTime.MinValue;
          }
        }
        private string GetSummary(string content)
        {
          string lContent = content.Trim('\"');
          int contentLength = 800;
          if (lContent.Length < 800)
            contentLength = lContent.Length;
          string _localContent = "";
          try
          {
            _localContent = WebBrowserHelper.StripHtml(lContent.Substring(0, contentLength));
          }
          catch
          {
          }
          if (_localContent.Length > 150)
            _localContent = _localContent.Substring(0, 150) + "...";
          return _localContent;
        
        }
      }
    }
    ​
