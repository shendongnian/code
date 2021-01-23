       var dic = new FluentDictionary<string, double?>();
        dic.Add("Field1", 1.0);
        dic.Add("Field2", 1.0);
       var response = Client.Search<T>(s => s
                                        .Skip(0)
                                        .Take(5)
                                        .Indices(indexes)
                                        .Query(q => q
                                            .MultiMatch(m => m
                                                .OnFieldsWithBoost(b => 
                                                {
                                                    foreach (var entry in dic)
                                                        b.Add(entry.Key, entry.Value);     
                                                })
                                                .Type(TextQueryType.Phrase)
                                                .Query("your query text")
                                                )
                                             )
                                        );
