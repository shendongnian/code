    public interface IBaseRepository<T> : IDisposable
    	where T : Entity.BaseModel, new()
    	{
    		List<T> GetItems();
    
    		T GetItem(int id);
    
    		int GetItemsCount();
    
    		int SaveItem(T item);
    
    		int SaveAllItem(IEnumerable<T> items);
    	}
    public class BaseRepository<T> : BaseRepository<T> where T : BaseModel, new()
    	{
    		private static readonly object locker = new object();
    		protected SQLiteConnection DatabaseConnection;
    		public BaseRepository(string dbPath)
    		{
    			DatabaseConnection = new SQLiteConnection(dbPath);
    			DatabaseConnection.CreateTable<T>();
    		}
    
    		public List<T> GetItems()
    		{
    			lock (locker)
    			{
    				return DatabaseConnection.Table<T>().ToList();
    			}
    		}
    
    		public int GetItemsCount()
    		{
    			lock (locker)
    			{
    				return DatabaseConnection.Table<T>().Count();
    			}
    		}
    
    		public T GetItem(int id)
    		{
    			lock (locker)
    			{
    				return DatabaseConnection.Table<T>().Where(i => i.Id == id).FirstOrDefault();
    			}
    		}
    
    		public int SaveItem(T item)
    		{
    			lock (locker)
    			{
    				if (item.Id != 0)
    				{
    					return DatabaseConnection.Update(item);
    				}
    				else
    				{
    					return DatabaseConnection.Insert(item);
    				}
    			}
    		}
    
    
    	}
