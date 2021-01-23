    public class EvenIntsList : IList<int>
    {
        private readonly IList<int> _list; 
        public EvenIntsList()
        {
            _list = new List<int>();
        }
        public void Add(int item)
        {
            if(item % 2 == 0)
                _list.Add(item);
            else
                throw new ArgumentException("This list only allows even integers.", "item");
        }
    }
