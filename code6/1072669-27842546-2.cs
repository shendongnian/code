    public class BaseUser<T> where T : SyncLists
    {
        protected virtual T SyncLists
        {
            get { return default(T); }
        }
    }
