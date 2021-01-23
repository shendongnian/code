    public class MasterDataViewModel<T> :  where T : BaseEntity, new()
    {
        public T CurrentItem { get; set; }
        public void ReloadItem(int id)
        {
            using (var context = new DatabaseContext())
            {
                CurrentItem = context.Set<T>.FirstOrDefault(x => x.Id == id)
            }
        }
    }
