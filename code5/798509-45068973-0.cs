    /// <summary>
    /// Maintains an observable (i.e. good for binding) collection of resources that can be indexed by name or alias
    /// </summary>
    /// <typeparam name="RT">Resource Type: the type of resource associated with this collection</typeparam>
    public class ResourceCollection<RT> : IEnumerable, INotifyCollectionChanged
        where RT : class, IResource, new()
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged
        {
            add { Ports.CollectionChanged += value; }
            remove { Ports.CollectionChanged -= value; }
        }
        public IEnumerator GetEnumerator() { return Ports.GetEnumerator(); }
        private ObservableCollection<RT> Ports { get; set; }
        private Dictionary<string, RT> ByAlias { get; set; }
        private Dictionary<string, RT> ByName { get; set; }
    }
