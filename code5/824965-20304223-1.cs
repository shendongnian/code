    public class TrackViewModel
    {
        public TrackViewModel(Track model)
        {
            Title = model.Title;
            Artists = string.Join(", ", model.Artists.Select(a => a.Name));
        }
    
        public string Title { get; private set; }
        public string Artists { get; private set; }
    }
