    public class SerializationModel
    {
        public Data Data { get; set; }
    }
    public class Data
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Id { get; set; }
        public Picture Picture { get; set; }
    }
    public class Picture
    {
        public PictureData Data { get; set; }
    }
    public class PictureData
    {
        public bool is_silhouette { get; set; }
        public string url { get; set; }
    }
