    public class DownloadsAvailableResult
    {
        // Other properties here
        // Just return the names, don't allow this to be set by user
        public string artistNames
        {
            get
            {
                return (artists == null)
                    ? string.Empty
                    : string.Join(", ", artists.Select(a => a.name));
            }
        }
    }
