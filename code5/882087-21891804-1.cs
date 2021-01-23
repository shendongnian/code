    var obj = JsonConvert.DeserializeObject<RootObject>(appJsonData);
---
    public class Result
    {
        public string kind { get; set; }
        public List<object> features { get; set; }
        public List<string> supportedDevices { get; set; }
        public bool isGameCenterEnabled { get; set; }
        public List<string> screenshotUrls { get; set; }
        public List<object> ipadScreenshotUrls { get; set; }
        public string artworkUrl60 { get; set; }
        public string artworkUrl512 { get; set; }
        public string artistViewUrl { get; set; }
        public int artistId { get; set; }
        public string artistName { get; set; }
        public double price { get; set; }
        public string version { get; set; }
        public string description { get; set; }
        public string currency { get; set; }
        public List<string> genres { get; set; }
        public List<string> genreIds { get; set; }
        public string releaseDate { get; set; }
        public string sellerName { get; set; }
        public string bundleId { get; set; }
        public int trackId { get; set; }
        public string trackName { get; set; }
        public string primaryGenreName { get; set; }
        public int primaryGenreId { get; set; }
        public string releaseNotes { get; set; }
        public string formattedPrice { get; set; }
        public string wrapperType { get; set; }
        public string trackCensoredName { get; set; }
        public List<string> languageCodesISO2A { get; set; }
        public string fileSizeBytes { get; set; }
        public string contentAdvisoryRating { get; set; }
        public double averageUserRatingForCurrentVersion { get; set; }
        public int userRatingCountForCurrentVersion { get; set; }
        public string artworkUrl100 { get; set; }
        public string trackViewUrl { get; set; }
        public string trackContentRating { get; set; }
    }
    public class RootObject
    {
        public int resultCount { get; set; }
        public List<Result> results { get; set; }
    }
