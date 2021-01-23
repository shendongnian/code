	solr.Setup(x => x.Query(It.IsAny<SolrQuery>()))
	                .Returns<SolrQuery>(s =>
	                {
	                    SolrQueryResults<Document> data = new SolrQueryResults<Document>();
	                    data.Add(new Document
	                        {
	                            Author = "Bob"
	                        });
	                    return data;
	                });
