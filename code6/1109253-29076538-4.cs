        var docs = new List<Document>
        {
            new Document{Text = "This is the first document", Number = 1 },
            new Document{Text = "This is the second document", Number =500 },
            new Document{Text = "This is the third document", Number = 1000 }
        };
        var searchDescriptor = new SearchDescriptor<Document>()
            .Index(indexName)
            .Query(q => q
                .Bool(b => b
                    .Should(s1 => s1
                        .Match(m => m
                            .Query("second")
                            .OnField(f => f.Text)),
                        s2 => s2
                            .Range(r =>r
                                .OnField(f => f.Number)
                                .Greater(750)))
                     .MinimumShouldMatch(1)))
            .Highlight(h => h
                .OnFields(f => f
                    .OnField(d => d.Text)
                    .PreTags("<em>")
                    .PostTags("</em>")));
      internal class Document
      {
          public string Text { get; set; }
          public int Number { get; set; }
      }
