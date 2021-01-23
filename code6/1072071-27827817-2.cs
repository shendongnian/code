	public class Thesaurus : IThesaurus
	{
		private Dictionary<string, List<string>> lookup = 
            new Dictionary<string, List<string>>(); 
		public void AddSynonyms(IEnumerable<string> synonyms)
		{
			var words = synonyms.Distinct().ToList();
			foreach (var word in words)
			{
                var currentWordSynonyms = words.Where(w => w ! == word).ToList();
				if (lookup.ContainsKey(word))
				{
					foreach (var synonym in currentWordSynonyms)
					{
						if(!lookup[word].Contains(synonym))
							lookup[word].Add(synonym);
					}
				}
				else
				{
					lookup.Add(word, currentWordSynonyms);
				}
			}
		}
		public IEnumerable<string> GetSynonyms(string word)
		{
			if(lookup.ContainsKey(word))
				return lookup[word];
			return Enumerable.Empty<string>();
			// Or throw an exception.
		}
		public IEnumerable<string> GetWords()
		{
			return lookup.Keys();
		}
	}
