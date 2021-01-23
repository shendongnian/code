    // usage:
    // var sortableList = new SortableList(m_personList);
    // dgv.DataSource = m_sortableList; 
    /// <summary>
    ///  Suitable for binding to DataGridView when column sorting is required
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SortableList<T> : BindingList<T>, IBindingListView
    {
        private PropertyComparerCollection<T> sorts;
    
        public SortableList()
        {
        }
    
        public SortableList(IEnumerable<T> initialList)
        {
            foreach (T item in initialList)
            {
                this.Add(item);
            }
        }
    
        public SortableList<T> ApplyFilter(Func<T, bool> func)
        {
            SortableList<T> newList = new SortableList<T>();
            foreach (var item in this.Where(func))
            {
                newList.Add(item);
            }
    
            return newList;
        }
    
        protected override bool IsSortedCore
        {
            get { return this.sorts != null; }
        }
    
        protected override bool SupportsSortingCore
        {
            get { return true; }
        }
    
        protected override ListSortDirection SortDirectionCore
        {
            get
            {
                return this.sorts == null
                           ? ListSortDirection.Ascending
                           : this.sorts.PrimaryDirection;
            }
        }
    
        protected override PropertyDescriptor SortPropertyCore
        {
            get
            {
                return this.sorts == null ? null : this.sorts.PrimaryProperty;
            }
        }
    
        public void ApplySort(ListSortDescriptionCollection
                                  sortCollection)
        {
            bool oldRaise = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            try
            {
                PropertyComparerCollection<T> tmp
                    = new PropertyComparerCollection<T>(sortCollection);
                List<T> items = new List<T>(this);
                items.Sort(tmp);
                int index = 0;
                foreach (T item in items)
                {
                    SetItem(index++, item);
                }
                this.sorts = tmp;
            }
            finally
            {
                RaiseListChangedEvents = oldRaise;
                ResetBindings();
            }
        }
    
        public bool Exists(Predicate<T> func)
        {
            return new List<T>(this).Exists(func);
        }
    
        string IBindingListView.Filter
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    
        void IBindingListView.RemoveFilter()
        {
            throw new NotImplementedException();
        }
    
        ListSortDescriptionCollection IBindingListView.SortDescriptions
        {
            get { return (this.sorts == null ? null : this.sorts.Sorts); }
        }
    
        bool IBindingListView.SupportsAdvancedSorting
        {
            get { return true; }
        }
    
        bool IBindingListView.SupportsFiltering
        {
            get { return false; }
        }
    
        protected override void RemoveSortCore()
        {
            this.sorts = null;
        }
    
        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            ListSortDescription[] arr = { new ListSortDescription(prop, direction) };
            ApplySort(new ListSortDescriptionCollection(arr));
        }
    }
    
    public class PropertyComparerCollection<T> : IComparer<T>
    {
        private readonly PropertyComparer<T>[] comparers;
    
        private readonly ListSortDescriptionCollection sorts;
    
        public PropertyComparerCollection(ListSortDescriptionCollection
                                              sorts)
        {
            if (sorts == null)
            {
                throw new ArgumentNullException("sorts");
            }
            this.sorts = sorts;
            List<PropertyComparer<T>> list = new
                List<PropertyComparer<T>>();
    
            foreach (ListSortDescription item in sorts)
            {
                list.Add(new PropertyComparer<T>(item.PropertyDescriptor,
                                                 item.SortDirection == ListSortDirection.Descending));
            }
    
            this.comparers = list.ToArray();
        }
    
        public ListSortDescriptionCollection Sorts
        {
            get { return this.sorts; }
        }
    
        public PropertyDescriptor PrimaryProperty
        {
            get
            {
                return this.comparers.Length == 0
                           ? null
                           : this.comparers[0].Property;
            }
        }
    
        public ListSortDirection PrimaryDirection
        {
            get
            {
                return this.comparers.Length == 0
                           ? ListSortDirection.Ascending
                           : this.comparers[0].Descending
                                 ? ListSortDirection.Descending
                                 : ListSortDirection.Ascending;
            }
        }
    
        int IComparer<T>.Compare(T x, T y)
        {
            int result = 0;
            foreach (PropertyComparer<T> t in this.comparers)
            {
                result = t.Compare(x, y);
                if (result != 0)
                {
                    break;
                }
            }
            return result;
        }
    }
    
    public class PropertyComparer<T> : IComparer<T>
    {
        private readonly bool descending;
    
        private readonly PropertyDescriptor property;
    
        public PropertyComparer(PropertyDescriptor property, bool descending)
        {
            if (property == null)
            {
                throw new ArgumentNullException("property");
            }
    
            this.descending = descending;
            this.property = property;
        }
    
        public bool Descending
        {
            get { return this.descending; }
        }
    
        public PropertyDescriptor Property
        {
            get { return this.property; }
        }
    
        public int Compare(T x, T y)
        {
            int value = Comparer.Default.Compare(this.property.GetValue(x),
                                                 this.property.GetValue(y));
            return this.descending ? -value : value;
        }
    }
