    var results = client.Search<SearchItem>(s => s.AllIndices()
		.Query(q =>
				q.Term(p => p.LastName, searchItem.LastName)
				&& q.Term(p => p.FirstName, searchItem.FirstName)
				&& q.Term(p => p.ApplicationCode, searchItem.ApplicationCode)
				)
		.Size(1000)
		);
    var list = results.Documents.ToList();
