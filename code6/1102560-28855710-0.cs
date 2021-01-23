    public class State : IList<string>
    {
        private List<string> internalList = new List<string>();
        public string this[int index]
        {
            get { return internalList[index]; }
            set { internalList[index] = value; }
        }
        public void Add (string item)
        {
            internalList.Add(item);
        }
        // etc. for the other IList<T> members
    }
