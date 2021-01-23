        public class RootJson
        {
            public List<Circle> CircleList { get; set; }
        }
        public class Circle
        {
            public int Density { get; set; }
            public int Friction { get; set; }
            public int Bounce { get; set; }
            public Filter CategoryBits { get; set; }
            public List<double> Shape { get; set; }
        }
        public class Filter
        {
            public int CategoryBits { get; set; }
            public int MaskBits { get; set; }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string Json = System.IO.File.ReadAllText(@"JsonFilePath");
            RootJson JCircle = JsonConvert.DeserializeObject<RootJson>(Json);
            Debug.Print(JCircle.CircleList.Count.ToString());
        }
