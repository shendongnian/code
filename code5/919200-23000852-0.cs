    using System;
    using System.Collections.Generic;
    using System.Linq;
    public abstract class RssItem
    {
        public virtual bool IsRead { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
    public class RssFeed : RssItem
    {
        public List<RssFeedArticle> Articles { get; set; }
        public override bool IsRead
        {
            get { return Articles.All(s => s.IsRead); }
            set { Articles.ForEach(s => s.IsRead = true); }
        }
    }
    public class RssFeedArticle : RssItem
    {
        public string Content { get; set; }
    }
