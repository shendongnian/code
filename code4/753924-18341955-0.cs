     using System.Linq; // For lambda operations
     (...)
     Songs = new ObservableCollection<Song>()
     {
        new Song() {Artist = Artists.FirstOrDefault(x => x.Name == "Francis Albert Sinatra"), SingerName = ...}
        (...)
     }
