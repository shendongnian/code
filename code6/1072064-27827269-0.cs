    public class Thesaurus :  IThesaurus
    {
    public void AddSynonyms(IEnumerable<string> synonyms){
    
     synonyms = new List<string>() { "one", "two", "three"};
    
    }
    
    public IEnumerable<string> GetSynonyms(string word){
    
    foreach(String s in AddSynonyms()){
    
         if(s == word)
            {
             yield return s;
    }
      }
    
    public IEnumerable<string> GetWords(){
    
    foreach(String s in AddSynonyms()){
    
             yield return s;
    }
    }
    }
