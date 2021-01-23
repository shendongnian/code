    public interface IThesaurus
    {
    
            IEnumerable<string> AddSynonyms();
            IEnumerable<string> GetSynonyms(string word);
    
            IEnumerable<string> GetWords();
        
    }
