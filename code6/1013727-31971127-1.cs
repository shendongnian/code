    var index = "my-application";
    var node = new Uri("http://localhost:9200");
    var settings = new ConnectionSettings(node, defaultIndex: index);
    var client = new ElasticClient(settings);
    // Create the index, indicating that the contents of the internal "file" field 
    // and the internal "title" field should be stored with position offsets to 
    // allow highlighting.
    client.CreateIndex(_index, c => c
        .AddMapping<Doc>(m => 
            m.Properties(ps => 
                ps.Attachment(a =>
                    a.Name(o => o.File)
                        .FileField(t => t.Name("file")
                        .TermVector(TermVectorOption.WithPositionsOffsets)
                        .Store()
                    ).TitleField(t => t                  
                     .Name("title")
                     .TermVector(TermVectorOption.WithPositionsOffsets)
                     .Store())
                 )
            ).Properties(ps =>
                ps.String(s => 
                    s.Name(o => o.Title)
                )
            )
        )
    );
    string path = @"path\to\sample1.pdf";
    var doc = new Doc()
    {
        Title = "Anything you want",
        File = Convert.ToBase64String(System.IO.File.ReadAllBytes(path))
    };
    client.Index(doc);
