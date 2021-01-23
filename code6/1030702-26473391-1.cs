     public class AdvancedContentLoader
     {    
         // no need for additionak parameters, works
         // with any loader, including the decorated one    
         public AdvancedContentLoader( IContentLoader c )
         {
            //save to backing fields
         }
  
         IEnumerable<T> LoadAllChildItems(Guid id){}  
      }     
