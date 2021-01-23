    public class DisplayItemCollectionBase<T> : ObservableCollection<DisplayItemBase<T>>
    {
       public DisplayItemCollectionBase(IEnumerable<T> items)
       {
           this.AddRange(items)
       }
       public void AddRange(IEnumerable<T> items)
       {
           foreach (var item in items)
              this.Add(item);
       }
       public void Add(T item)
       {
          this.Add(new DisplayItemBase<T>(item));
       }
    }
