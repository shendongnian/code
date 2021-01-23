    public class MasterDataViewModel<T> :  where T : IDBEntity, new()
    {
        public T CurrentItem { get; set; }
    
        public void ReloadItem(int id)
        {
            using (var context = new DatabaseContext())
            {
                CurrentItem = context.Set<T>().Find(id);
            }
        }
    }
