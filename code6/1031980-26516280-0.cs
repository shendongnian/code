    var photos = JsonConvert.DeserializeObject<List<Photo>>(json);
---
    public class Photo
    {
        public List<object> children { get; set; }
        public string id { get; set; }
        public string site { get; set; }
        public List<string> authorNames { get; set; }
        public string captionTranscript { get; set; }
        public string type { get; set; }
        public string subType { get; set; }
        public string shotTypeAbbreviation { get; set; }
        public List<string> photoSrcs { get; set; }
        public string source { get; set; }
        public int vdpOrder { get; set; }
    }
