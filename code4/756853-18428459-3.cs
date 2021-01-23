      class SortableCollection<T> : Collection<T>
      {
          public SortableCollection() : this(new List<T>) {}
          public SortableCollection(List<T> list) : base(list) {}
          public virtual void Sort() { ((List<T>)Items).Sort(); }
      }
     
      class CustomSortableCollection : SortableCollection<string>
      {
           public override Sort() { ((List<string>)Items).Sort(CustomComparer.Default) };
      }
     
