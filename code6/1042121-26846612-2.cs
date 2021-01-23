    public class MoniGridModel
    {
        private List<MoniModel> moniDetails;
        public MoniGridModel()
        {
            this.moniDetails = new List<MoniModel>();
        }
        public IEnumerable<MoniModel> MoniDetails
        {
            get { return this.moniDetails; }
        }
        public void AddDetail(moniDetail detail)
        {
            this.moniDetails.Add(detail);
        }
    }
