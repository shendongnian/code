    public class Thesaurus : IThesaurus
    {
           public IEnumerable<string> AddSynonyms()
           {
              return new List<string>() {"one", "two", "three"};
           }
    
           public IEnumerable<string> GetSynonyms(string word)
           {
               return AddSynonyms().Where(s => s == word);
           }
    
           public IEnumerable<string> GetWords()
           {
               return AddSynonyms();
           }
    }
