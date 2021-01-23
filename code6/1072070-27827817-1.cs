	public class Thesaurus : IThesaurus
	{
		private Dictionary<string, List<string>> lookup = 
            new Dictionary<string, List<string>>(); 
		public void AddSynonyms(IEnumerable<string> synonyms)
		{
			var words = synonyms.Distinct().ToList();
			foreach (var word in words)
			{
				if (lookup.ContainsKey(word))
				{
					foreach (var synonym in words.Where(w => w != word))
					{
						if(!lookup[word].Contains(synonym))
							lookup[word].Add(synonym);
					}
				}
				else
				{
					lookup.Add(word, words.Where(w => w != word).ToList());
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
