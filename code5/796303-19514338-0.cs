    public class Holder<T> where T : IObject
    {
        private T myItem = Activator.CreateInstance<T>();
        
        public void ChangeItemList(T item)
        {
            myItem.List = item.List;
        }
    }
