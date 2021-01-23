    using System;
    using System.Net;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Ink;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Shapes;
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Globalization;
    namespace FeedModel.Classes
    {
      public enum ArticleOpenMode {OpenWebPage,UseContent, Mobilizer};
      public class Article
      {
        private string _id;
        protected DateTime _publishedDate;
        protected DateTime _crawlTime;
        private string _author;
        private string _title;
        private string _content;
        private string _summary;
        private string _url;
        protected bool _read;
        protected bool _starred;
        private string _rawDate;
        private string _rawCrawlTime;
        private ArticleOpenMode _openMode;
        protected List<string> _tags;
        private string _feedProviderName;
        private string _feedTitle;
        private string _feedUrl;
        private string _feedId;
        private string _image;
        private AccountTypes _accountType;
        public Article()
        {
          _tags = new List<string>();
          _image = "";
        }
        public ArticleOpenMode OpenMode
        {
          get { return _openMode; }
          set { _openMode = value; }
        }
        public bool Read
        {
          get { return _read; }
          set { _read = value; }
        }
        public bool Starred
        {
          get { return _starred; }
          set { _starred = value; }
        }
        public string Image
        {
          get { return _image; }
          set { _image = value; }
        }
        public string FeedProviderName
        {
          get { return _feedProviderName; }
          set { _feedProviderName = value; }
        }
        public string FeedTitle
        {
          get { return _feedTitle; }
          set { _feedTitle = value; }
        }
        public string FeedUrl
        {
          get { return _feedUrl; }
          set { _feedUrl = value; }
        }
        public string FeedId
        {
          get { return _feedId; }
          set { _feedId = value; }
        }
        public string Url
        {
          get { return _url; }
          set { _url = value; }
        }
        public string Content
        {
          get { return _content; }
          set { _content = value; }
        }
        public string Summary
        {
          get { return _summary; }
          set { _summary = value; }
        }
        public string Title
        {
          get { return _title; }
          set { _title = value; }
        }
        public string Author
        {
          get { return _author; }
          set { _author = value; }
        }
        public DateTime PublishedDate
        {
          get { return _publishedDate; }
          set { _publishedDate = value; }
        }
        public DateTime CrawlTime
        {
          get { return _crawlTime; }
          set { _crawlTime = value; }
        }
        public string Id
        {
          get { return _id; }
          set { _id = value; }
        }
        public List<string> Tags
        {
          get { return _tags; }
          set { _tags = value; }
        }
        public string RawPublishDate
        {
          get { return _rawDate; }
          set
          {
            Double seconds;
            _rawDate = value;
            try
            {
              seconds = Convert.ToDouble(_rawDate);
              DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
              _publishedDate = origin.AddSeconds(seconds);
            }
            catch
            {
              _publishedDate = DateTime.Now;
            }
          }
        }
        public string RawCrawlTime
        {
          get { return _rawCrawlTime; }
          set
          {
            Double seconds;
            _rawCrawlTime = value;
            //try
            //{
            //  seconds = Convert.ToDouble(_rawCrawlTime);
            //  DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            //  _crawlTime = origin.AddSeconds(seconds);
            //}
            //catch
            //{
              _crawlTime = DateTime.Now;
            //}
          }
        }
        public AccountTypes AccountType
        {
          get { return _accountType; }
          set { _accountType = value; }
        }
      }
    }
