    public class FacebookModel
    {
        public string id { get; set; }
        public AlbumModel albums { get; set; }
    }
    
    public class AlbumModel
    {
        public List<AlbumData> data {get;set;}
    }
    
    public class AlbumData
    {
        public string id { get; set; }
        public string name { get; set; }
        public PictureModel photos { get; set; }
    }
    
    public class PictureModel
    {
        public List<PictureData> data {get;set;}
    }
    
    public class PictureData
    {
        public string id { get; set; }
        public string picture { get; set; }
    }
