			//we want to search/filter
			if (!string.IsNullOrEmpty(request.SearchText))
			{
				var searchTerms = request.SearchText.ToLower().Split(null);
				foreach (var term in searchTerms)
				{
					string tmpTerm = term;
					query = query.Where(
						x =>
							x.Name.ToLower().Contains(tmpTerm)
						);
				}
			}
