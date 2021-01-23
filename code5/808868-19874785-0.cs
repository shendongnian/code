    var partialName = new CustomAnalyzer
                {
                    Filter = new List<string> {"lowercase", "name_ngrams", "standard", "asciifolding"},
                    Tokenizer = "standard"
                };
    var fullName = new CustomAnalyzer
                {
                    Filter = new List<string> {"standard", "lowercase", "asciifolding"},
                    Tokenizer = "standard"
                };
    client.CreateIndex("indexname", c => c
                    .Analysis(descriptor => descriptor
                        .TokenFilters(bases => bases.Add("name_ngrams", new EdgeNGramTokenFilter
                        {
                            MaxGram = 20,
                            MinGram = 2,
                            Side = "front"
                        }))
                        .Analyzers(bases => bases
                            .Add("partial_name", partialName)
                            .Add("full_name", fullName))
                    )
                    .AddMapping<Company>(m => m
                        .Properties(o => o
                            .String(i => i
                                .Name(x => x.Name)
                                .IndexAnalyzer("partial_name")
                                .SearchAnalyzer("full_name")
                            ))));
