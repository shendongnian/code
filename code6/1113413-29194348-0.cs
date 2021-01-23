    public abstract class TreeRoot : ITreeNode, IDisposable
    {
        private readonly IList<ITreeChild> children = new ObservableCollection<ITreeChild>();
        public IList<ITreeChild> Children
        {
            get
            {
                return children;
            }
        }
        protected virtual void OnChildCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (var item in e.OldItems)
                {
                    var treeItem = item as ITreeChild;
                    if (treeItem == null)
                    {
                        continue;
                    }
                    treeItem.Parent = null;
                }
            }
            if (e.NewItems != null)
            {
                foreach (var item in e.NewItems)
                {
                    var treeItem = item as ITreeChild;
                    if (treeItem == null)
                    {
                        continue;
                    }
                    treeItem.Parent = this;
                }
            }
        }
        private bool isDisposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }
            if (isDisposed)
            {
                return;
            }
            isDisposed = true;
            Destroy();
        }
        public void Dispose()
        {
            Dispose(true);
        }
        public void Init()
        {
            var colc = Children as INotifyCollectionChanged;
            if (colc != null)
            {
                colc.CollectionChanged += OnChildCollectionChanged;
            }
        }
        public void Destroy()
        {
            Children.Clear();
            var colc = Children as INotifyCollectionChanged;
            if (colc != null)
            {
                colc.CollectionChanged -= OnChildCollectionChanged;
            }
        }
    }
