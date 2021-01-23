     public class SampleResponse
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }
        [JsonProperty("totalItems")]
        public int TotalItems { get; set; }
        [JsonProperty("items")]
        public Item[] Items { get; set; }
    }
    public class AccessInfo
    {
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("viewability")]
        public string Viewability { get; set; }
        [JsonProperty("embeddable")]
        public bool Embeddable { get; set; }
        [JsonProperty("publicDomain")]
        public bool PublicDomain { get; set; }
        [JsonProperty("textToSpeechPermission")]
        public string TextToSpeechPermission { get; set; }
        [JsonProperty("epub")]
        public Epub Epub { get; set; }
        [JsonProperty("pdf")]
        public Pdf Pdf { get; set; }
        [JsonProperty("webReaderLink")]
        public string WebReaderLink { get; set; }
        [JsonProperty("accessViewStatus")]
        public string AccessViewStatus { get; set; }
    }
     public class Epub
    {
        [JsonProperty("isAvailable")]
        public bool IsAvailable { get; set; }
    }
     public class ImageLinks
    {
        [JsonProperty("smallThumbnail")]
        public string SmallThumbnail { get; set; }
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
    }
    public class IndustryIdentifier
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("identifier")]
        public string Identifier { get; set; }
    }
    
    public class Item
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("etag")]
        public string Etag { get; set; }
        [JsonProperty("selfLink")]
        public string SelfLink { get; set; }
        [JsonProperty("volumeInfo")]
        public VolumeInfo VolumeInfo { get; set; }
        [JsonProperty("saleInfo")]
        public SaleInfo SaleInfo { get; set; }
        [JsonProperty("accessInfo")]
        public AccessInfo AccessInfo { get; set; }
    }
     public class Pdf
    {
        [JsonProperty("isAvailable")]
        public bool IsAvailable { get; set; }
    }
      public class SaleInfo
    {
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("saleability")]
        public string Saleability { get; set; }
        [JsonProperty("isEbook")]
        public bool IsEbook { get; set; }
    }
      public class VolumeInfo
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("authors")]
        public string[] Authors { get; set; }
        [JsonProperty("publisher")]
        public string Publisher { get; set; }
        [JsonProperty("publishedDate")]
        public string PublishedDate { get; set; }
        [JsonProperty("industryIdentifiers")]
        public IndustryIdentifier[] IndustryIdentifiers { get; set; }
        [JsonProperty("pageCount")]
        public int PageCount { get; set; }
        [JsonProperty("printType")]
        public string PrintType { get; set; }
        [JsonProperty("contentVersion")]
        public string ContentVersion { get; set; }
        [JsonProperty("imageLinks")]
        public ImageLinks ImageLinks { get; set; }
        [JsonProperty("language")]
        public string Language { get; set; }
        [JsonProperty("previewLink")]
        public string PreviewLink { get; set; }
        [JsonProperty("infoLink")]
        public string InfoLink { get; set; }
        [JsonProperty("canonicalVolumeLink")]
        public string CanonicalVolumeLink { get; set; }
    }
