    public abstract class TableEntity<TKey>
    {
    }
    public class BusinessObject<TEntity, TKey>
        where T : TableEntity<TKey>
    {
        public TEntity GetOne(TKey key)
        {
            // ...
        }
    }
