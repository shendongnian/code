      class SortableCollection<T> : System.Collections.ObjectModel.Collection<T>
      {
        public SortableCollection() : this(new List<T>()) {}
        public SortableCollection(List<T> list) : base(list) {}
        public virtual void Sort() { ((List<T>)Items).Sort(); }
      }
      class CustomSortableCollection<T> : SortableCollection<T> where T: INamed
      {
        public override void Sort() { 
           ((List<INamed>)Items).Sort(CustomComparer.Default); 
        }
      }
     
