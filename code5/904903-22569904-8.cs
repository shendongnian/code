    public class KnowledgeService
    {
       private readonly YourDbContext db;
       public KnowledgeService(YourDbContext db)
       {
           this.db = db;
       }
       
       public IEnumerable<KnowledgebaseViewModel> GetSuggestionsByTags(IEnumerable<string> tags)
       {
          //Here goes logic for getting suggestions
       }
    }
