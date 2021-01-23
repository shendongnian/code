    public class MoniGridModel
    {
        public IEnumerable<MoniModel> MoniDetails { get; set; }
        public MoniGridModel()
        {
            MoniDetails = new List<MoniModel>();
        }
    }
