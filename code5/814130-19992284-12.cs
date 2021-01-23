    public class FileEntry : NamedTreeEntry
    {
		// ... and other file-specific public properties and methods
    }
    public class DirectoryEntry : NamedTreeEntry
    {
        public ObservableCollection<NamedTreeEntry> ChildEntries
        {
            get { return _collChildren; }
        }
        private readonly ObservableCollection<NamedTreeEntry> _collChildren;
        public DirectoryEntry(IEnumerable<NamedTreeEntry> childEntries)
        {
            _collChildren = (childEntries != null) ?
                new ObservableCollection<NamedTreeEntry>(childEntries)
                : new ObservableCollection<NamedTreeEntry>();
        }
        // ... and other directory-specific public properties and methods
    }
