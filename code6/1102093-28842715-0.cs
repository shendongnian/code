    public class DataContainer
    {
        public List<string> Labels { get; set; }
        public List<DataSet> DataSets { get; set; }
    }
    public class DataSet
    {
        public string Label { get; set; }
        public string FillColor { get; set; }
        public string StrokeColor { get; set; }
        public string PointColor { get; set; }
        public string PointStrokeColor { get; set; }
        public string PointHighlightFill { get; set; }
        public string PointHighlightStroke { get; set; }
        public List<int> Data { get; set; }
    }
