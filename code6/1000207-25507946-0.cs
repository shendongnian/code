    public class CollectionSong<T> : ObservableCollection<T>  where T : BaseSong
    {
       public CollectionSong<ExtendedSong> ToExSongs() {...}
    }
    public CollectionSong<BaseSong> CollectionEx
        { 
             get { return Collection.ToExSongs(); }
             set {...}
        }
