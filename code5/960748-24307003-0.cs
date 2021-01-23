        [Route("test")]
        public HttpResponseMessage Get()
        {
            var feed = new SyndicationFeed("Test Feed", "This is a test feed",
                                           new Uri("http://google.com"));
            feed.Categories.Add(new SyndicationCategory("test"));
            feed.Description = new TextSyndicationContent("This is a test feed to see how easy it is");
            var test = new SyndicationItem("blah.blah@test.com", "this is a note",
                                           new Uri("http://google.com"), "blah.blah@test.com",
                                           DateTime.Now);
            test.Categories.Add(new SyndicationCategory("Person"));
            test.Authors.Add(new SyndicationPerson("blah@blah.com"));
            var test2 = new SyndicationItem("blah.blah@test2.com", "this is a note",
                                           new Uri("http://google.com"), "blah.blah@test2.com",
                                           DateTime.Now);
            test2.Categories.Add(new SyndicationCategory("Person"));
            test2.Authors.Add(new SyndicationPerson("blah@blah.com"));
            var items = new List<SyndicationItem> { test, test2 };
            feed.Items = items;
            var formatter = new Rss20FeedFormatter(feed);
            var output = new MemoryStream();
            
            var xws = new XmlWriterSettings {Encoding = Encoding.UTF8};
            using (var xmlWriter = XmlWriter.Create(output, xws))
            {
                formatter.WriteTo(xmlWriter);
                xmlWriter.Flush();
            }
            string xml;
            using (var sr = new StreamReader(output))
            {
                output.Position = 0;
                xml = sr.ReadToEnd();
                sr.Close();
            }
            var response = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(xml, Encoding.UTF8, "application/xml")};
            return response;
        }
