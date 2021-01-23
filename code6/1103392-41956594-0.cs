    //for Pass data to Chart
        public class Dataset
        {
            public Dataset()
            {
                data = new List<int>();
            }
            public string label { get; set; }
            public string fillColor { get; set; }
            public string strokeColor { get; set; }
            public string pointColor { get; set; }
            public List<int> data { get; set; }
        }
    
        public class RootObject
        {
            public RootObject()
            {
                labels = new List<string>();
                datasets = new List<Dataset>();
            }
            public List<string> labels { get; set; }
            public List<Dataset> datasets { get; set; }
        }
