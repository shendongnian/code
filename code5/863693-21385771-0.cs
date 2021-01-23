    public class TestViewModel
    {
        public List<InnerViewModel> ModelData { get; set; }
        public class InnerViewModel
        {
            public int Id { get; set; }
            public bool Checked { get; set; }
        }
    }
