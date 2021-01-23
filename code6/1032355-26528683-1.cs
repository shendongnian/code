    public class MasterViewModel
    {
        public MyViewModel VM1 { get; set; }
        public MyViewModel VM2 { get; set; }
        public MasterViewModel()
        {
            this.VM1 = new MyViewModel();
            this.VM2 = new MyViewModel();
            VM1.DataInfo.Add("Data 1-1");
            VM1.DataInfo.Add("Data 1-2");
            VM2.DataInfo.Add("Data 2-1");
            VM2.DataInfo.Add("Data 2-2");
        }
    }
