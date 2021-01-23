    public class TrackViewModel
    {
        public TrackViewModel(Track model)
        {
            Title = model.Title;
            Artists = string.Join(", ", model.Artists);
        }
    
        public string Title { get; private set; }
        public string Artists { get; private set; }
    }
