    [XmlType(TypeName = "Image")]
    public class ImageSerializationContainer
    {
        [XmlElement(ElementName = "indx")]
        public int Index { get; set; }
        [XmlElement(ElementName = "filepath")]
        public string FilePath { get; set; }
    }
    [XmlType(TypeName = "Album")]
    public class AlbumSerializationContainer
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CoverImgIndx { get; set; }
        public List<ImageSerializationContainer> Images { get; set; }
    }
