    public class FakeProcessor : IProcessor
    {
        private IList<int> mList = new List<int>();
        public IList<int> MyArgsIds 
        {
            get { return mList; }
        }
        public void Process(MyArgs args)
        {
            mList.Add(args.Id);
        }
    }
