    public class DownloadsAvailableResult
    {
        // Other properties here
        // Just return the names, don't allow this to be set by user 
        // (to add an artist name, add an Artist to the artists List)
        public string artistNames
        {
            get
            {
                return (artists == null)
                    ? string.Empty // <-- or something like: "<No Artist Info Available>"
                    : string.Join(", ", artists.Select(a => a.name));
            }
        }
    }
