    public class GenericCollectionView<T> : ICollectionView<T>, IEditableCollectionView<T>
    {
        #region Fields
        [NotNull] readonly ListCollectionView collectionView;
        #endregion
        #region Properties
        public CultureInfo Culture
        {
            get => collectionView.Culture;
            set => collectionView.Culture = value;
        }
        public IEnumerable SourceCollection => collectionView.SourceCollection;
        public Predicate<object> Filter
        {
            get => collectionView.Filter;
            set => collectionView.Filter = value;
        }
        public bool CanFilter => collectionView.CanFilter;
        public SortDescriptionCollection SortDescriptions => collectionView.SortDescriptions;
        public bool CanSort => collectionView.CanSort;
        public bool CanGroup => collectionView.CanGroup;
        public ObservableCollection<GroupDescription> GroupDescriptions => collectionView.GroupDescriptions;
        public ReadOnlyObservableCollection<object> Groups => collectionView.Groups;
        public bool IsEmpty => collectionView.IsEmpty;
        public object CurrentItem => collectionView.CurrentItem;
        public int CurrentPosition => collectionView.CurrentPosition;
        public bool IsCurrentAfterLast => collectionView.IsCurrentAfterLast;
        public bool IsCurrentBeforeFirst => collectionView.IsCurrentBeforeFirst;
        public NewItemPlaceholderPosition NewItemPlaceholderPosition
        {
            get => collectionView.NewItemPlaceholderPosition;
            set => collectionView.NewItemPlaceholderPosition = value;
        }
        public bool CanAddNew => collectionView.CanAddNew;
        public bool IsAddingNew => collectionView.IsAddingNew;
        public object CurrentAddItem => collectionView.CurrentAddItem;
        public bool CanRemove => collectionView.CanRemove;
        public bool CanCancelEdit => collectionView.CanCancelEdit;
        public bool IsEditingItem => collectionView.IsEditingItem;
        public object CurrentEditItem => collectionView.CurrentEditItem;
        #endregion
        #region Events
        public event NotifyCollectionChangedEventHandler CollectionChanged
        {
            add => ((ICollectionView) collectionView).CollectionChanged += value;
            remove => ((ICollectionView) collectionView).CollectionChanged -= value;
        }
        public event CurrentChangingEventHandler CurrentChanging
        {
            add => ((ICollectionView) collectionView).CurrentChanging += value;
            remove => ((ICollectionView) collectionView).CurrentChanging -= value;
        }
        public event EventHandler CurrentChanged
        {
            add => ((ICollectionView) collectionView).CurrentChanged += value;
            remove => ((ICollectionView) collectionView).CurrentChanged -= value;
        }
        #endregion
        #region Constructors
        public GenericCollectionView([NotNull] ListCollectionView collectionView)
        {
            this.collectionView = collectionView ?? throw new ArgumentNullException(nameof(collectionView));
        }
        #endregion
        #region Methods
        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>) ((ICollectionView) collectionView).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((ICollectionView) collectionView).GetEnumerator();
        }
        public bool Contains([NotNull] object item)
        {
            return collectionView.Contains(item);
        }
        public void Refresh()
        {
            collectionView.Refresh();
        }
        public IDisposable DeferRefresh()
        {
            return collectionView.DeferRefresh();
        }
        public bool MoveCurrentToFirst()
        {
            return collectionView.MoveCurrentToFirst();
        }
        public bool MoveCurrentToLast()
        {
            return collectionView.MoveCurrentToLast();
        }
        public bool MoveCurrentToNext()
        {
            return collectionView.MoveCurrentToNext();
        }
        public bool MoveCurrentToPrevious()
        {
            return collectionView.MoveCurrentToPrevious();
        }
        public bool MoveCurrentTo(object item)
        {
            return collectionView.MoveCurrentTo(item);
        }
        public bool MoveCurrentToPosition(int position)
        {
            return collectionView.MoveCurrentToPosition(position);
        }
        public object AddNew()
        {
            return collectionView.AddNew();
        }
        public void CommitNew()
        {
            collectionView.CommitNew();
        }
        public void CancelNew()
        {
            collectionView.CancelNew();
        }
        public void RemoveAt(int index)
        {
            collectionView.RemoveAt(index);
        }
        public void Remove([NotNull] object item)
        {
            collectionView.Remove(item);
        }
        public void EditItem(object item)
        {
            collectionView.EditItem(item);
        }
        public void CommitEdit()
        {
            collectionView.CommitEdit();
        }
        public void CancelEdit()
        {
            collectionView.CancelEdit();
        }
        #endregion
    }
