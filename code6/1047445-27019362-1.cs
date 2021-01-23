    public class SpecialGroup:Group
    {
        public SpecialGroup(object key, IEnumerable<DataRow> source, List<string> columnList) 
                                 : base(key, source, columnList)
        {
        }
    
        public void DoSomething()
        {
            // do something
        }
    
        protected override Group CreateGroup(object key, IEnumerable<DataRow> source, List<string> columnList)
        {
            return new SpecialGroup(key, source, columnList)
        }
    }
