    public class MultiMediaList : ObservableCollection<Multimedia>
    {
        //... constructor with creating several default objects of Multimedia
    
        public void addMedia(string title, string artist, string genre, MediaType type)
        {
            this.Add(new Multimedia(title, artist, genre, type));
        }
    }
