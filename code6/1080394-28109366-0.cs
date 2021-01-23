    public class TestTemplate<T>
        where T : ITrackedItem, new() 
    {
        public SortedSet<T> Set { get; set; }
        public void Test()
        {
            Set = new SortedSet<T>();
            foreach (var item in Set)
            {
                // cannot access any properties here
                // var ID = item.ID; <=============|
            }
        }
    }
