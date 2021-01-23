    public class BinarySegment
    {
        private const string FileName = "SegmentData.xml";
        private static XmlSerializer serializer = new XmlSerializer(typeof(List<BinarySegment>));
        public string SegmentName { get; set; }
        public long SegmentStartIndex { get; set; }
        public long SegmentLength { get; set; }
        public static List<BinarySegment> LoadFromFile()
        {
            if (!File.Exists(FileName))
            {
                throw new Exception("File must be created first");
            }
            try
            {
                using (StreamReader sr = new StreamReader(FileName))
                {
                    return serializer.Deserialize(sr) as List<BinarySegment>;
                }
            }
            catch
            {
                throw new Exception("File as become corrupted");
            }
        }
        public static void Save(List<BinarySegment> list)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(FileName))
                {
                    serializer.Serialize(sw, list);
                }
            }
            catch
            {
                throw;
            }
        }
    }
