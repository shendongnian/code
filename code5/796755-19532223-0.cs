    public interface IItemRetriever{
        public IEnumerable<IItem> GetList();
    }
    public class StandardItemRetriever : IItemRetriever{
        public IEnumerable<IItem> GetList(){
            // returning the data
        }
    }
    public class CachedStandardItemRetriever : IItemRetriever{
        public CachedStandardItemRetriever(StandardItemRetriever standardItemRetriever){
            // property assignment
        }
        IEnumerable<IItem> items;
        public IEnumerable<IItem> GetList(){
            if(items == null || !items.Any())
            {
                items = this.standardItemRetriever.GetList();
            }
            return items;
        }
    }
    public class StandardItemExistanceVerifier{
        public StandardItemExistanceVerifier(IItemRetriever iItemRetriever){
            // property assignment
        }
    }
