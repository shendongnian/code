    public class Note : INotifyPropertyChanged
    {
        // Only the IsSelected property because a Note can not be expanded
        public bool IsSelected { get { /* ... */ } set { /* ... */ } }
    }
    public class NoteFolder : INotifyPropertyChanged
    {
        public bool IsSelected { get { /* ... */ } set { /* ... */ } }
        public bool IsExpanded { get { /* ... */ } set { /* ... */ } }
    }
