    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Elasticsearch.Net.ConnectionPool;
    using Nest;
    namespace ESTester
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                const string indexName = "testindex";
                var connectionSettings = new ConnectionSettings(new SingleNodeConnectionPool(new Uri("http://127.0.0.1:9200")));
                var client = new ElasticClient(connectionSettings);
                var existResponse = client.IndexExists(descriptor => descriptor.Index(indexName));
                if (existResponse.Exists)
                    client.DeleteIndex(descriptor => descriptor.Index(indexName));
                // Making sure the refresh interval is low, since it's boring to have to wait for things to catch up
                client.PutTemplate("", descriptor => descriptor.Name("testindex").Template("testindex").Settings(objects => objects.Add("index.refresh_interval", "1s")));
                client.CreateIndex(descriptor => descriptor.Index(indexName));
                var docs = new List<Document>
                {
                    new Document{Text = "This is the first document" },
                    new Document{Text = "This is the second document" },
                    new Document{Text = "This is the third document" }
                };
                var bulkDecsriptor = new BulkDescriptor().IndexMany(docs, (descriptor, document) => descriptor.Index(indexName));
                client.Bulk(bulkDecsriptor);
                // Making sure ES has indexed the documents
                Thread.Sleep(TimeSpan.FromSeconds(2));
                var searchDescriptor = new SearchDescriptor<Document>()
                    .Index(indexName)
                    .Query(q => q
                        .Match(m => m
                            .OnField(d => d.Text)
                            .Query("the second")))
                    .Highlight(h => h
                        .OnFields(f => f
                            .OnField(d => d.Text)
                            .PreTags("<em>")
                            .PostTags("</em>")));
                var result = client.Search<Document>(searchDescriptor);
                if (result.Hits.Any())
                {
                    foreach (var hit in result.Hits)
                    {
                        Console.WriteLine("Found match: {0}", hit.Source.Text);
                        if (!hit.Highlights.Any()) continue;
                        foreach (var highlight in hit.Highlights.SelectMany(highlight => highlight.Value.Highlights))
                        {
                            Console.WriteLine("Found highlight: {0}", highlight);
                        }
                    }
                }
                Console.WriteLine("Press any key to exit!");
                Console.ReadLine();
            }
        }
        internal class Document
        {
            public string Text { get; set; }
        }
    }
