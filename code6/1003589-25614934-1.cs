    class FilterThis : IFilter<ATestObject>
    {
        public IEnumerable<ATestObject> Filter(IEnumerable<ATestObject> queryableBase)
        {
            return queryableBase.Where(o => o.FirstName == "Chris");
        }
    }
    public class ATestObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
