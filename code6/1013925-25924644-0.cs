    using System;
    using System.IO;
    using System.Collections;
    using System.Xml.Serialization;
    
    namespace ConsoleApplication3
    {
        public class UrlSerializer
        {
            private static void Write(string filename)
            {
                URLCollection urls = new URLCollection();
                urls.Add(new Url { Address = "http://www.google.com", Order = 1 });
                urls.Add(new Url { Address = "http://www.yahoo.com", Order = 2 });
                XmlSerializer x = new XmlSerializer(typeof(URLCollection));
                TextWriter writer = new StreamWriter(filename);
                x.Serialize(writer, urls);
            }
    
            private static URLCollection Read(string filename)
            {
                var x = new XmlSerializer(typeof(URLCollection));
                TextReader reader = new StreamReader(filename);
                var urls = (URLCollection)x.Deserialize(reader);
                return urls;
            }
        }
    
        public class URLCollection : ICollection
        {
            public string CollectionName;
            private ArrayList _urls = new ArrayList();
    
            public Url this[int index]
            {
                get { return (Url)_urls[index]; }
            }
    
            public void CopyTo(Array a, int index)
            {
                _urls.CopyTo(a, index);
            }
    
            public int Count
            {
                get { return _urls.Count; }
            }
    
            public object SyncRoot
            {
                get { return this; }
            }
    
            public bool IsSynchronized
            {
                get { return false; }
            }
    
            public IEnumerator GetEnumerator()
            {
                return _urls.GetEnumerator();
            }
    
            public void Add(Url url)
            {
                if (url == null) throw new ArgumentNullException("url");
                _urls.Add(url);
            }
        }
    }
