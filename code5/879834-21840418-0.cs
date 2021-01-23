    namespace Kaiser.Training.Data.JSONClasses
    {
    
        public class MarvelResponse
        {
            public int code { get; set; }
            public string status { get; set; }
            public string etag { get; set; }
            public Data data { get; set; }
        }
    
        public class Data
        {
            public int offset { get; set; }
            public int limit { get; set; }
            public int total { get; set; }
            public int count { get; set; }
            public Result[] results { get; set; }
        }
    
        public class Result
        {
            public int id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public DateTime modified { get; set; }
            public Thumbnail thumbnail { get; set; }
            public string resourceURI { get; set; }
            public Comics comics { get; set; }
            public Series series { get; set; }
            public Stories stories { get; set; }
            public Events events { get; set; }
            public Url[] urls { get; set; }
        }
    
        public class Thumbnail
        {
            public string path { get; set; }
            public string extension { get; set; }
        }
    
        public class Comics
        {
            public int available { get; set; }
            public string collectionURI { get; set; }
            public ComicResourceUriItem[] items { get; set; }
            public int returned { get; set; }
        }
    
        public class ComicResourceUriItem
        {
            public string resourceURI { get; set; }
            public string name { get; set; }
        }
    
        public class Series
        {
            public int available { get; set; }
            public string collectionURI { get; set; }
            public SeriesResourceItem[] items { get; set; }
            public int returned { get; set; }
        }
    
        public class SeriesResourceItem
        {
            public string resourceURI { get; set; }
            public string name { get; set; }
        }
    
        public class Stories
        {
            public int available { get; set; }
            public string collectionURI { get; set; }
            public StoriesResourceItem[] items { get; set; }
            public int returned { get; set; }
        }
    
        public class StoriesResourceItem
        {
            public string resourceURI { get; set; }
            public string name { get; set; }
            public string type { get; set; }
        }
    
        public class Events
        {
            public int available { get; set; }
            public string collectionURI { get; set; }
            public EventsResourceUriItem[] items { get; set; }
            public int returned { get; set; }
        }
    
        public class EventsResourceUriItem
        {
            public string resourceURI { get; set; }
            public string name { get; set; }
        }
    
        public class Url
        {
            public string type { get; set; }
            public string url { get; set; }
        }
    
    }
