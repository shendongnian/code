    public interface ISomething
    {
        void DoSomething();
    }
    public class SomethingManager : ISomething 
    {
        private List<ISomething> _items = new List<ISomething>();
        public void DoSomething()
        {
            _items.ForEach(i => i.DoSomething());
        }
    } 
